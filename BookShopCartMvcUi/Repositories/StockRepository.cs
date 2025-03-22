using Microsoft.EntityFrameworkCore;

namespace FilmShopMVC.Repositories
{
	public class StockRepository : IStockRepository
	{
		private readonly ApplicationDbContext _context;

		public StockRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Stock?> GetStockByBookId(int filmId) => await _context.Stocks.FirstOrDefaultAsync(s => s.FilmId == filmId);

		public async Task ManageStock(StockDTO stockToManage)
		{
			// if there is no stock for given film id, then add new record
			// if there is already stock for given film id, update stock's quantity
			var existingStock = await GetStockByBookId(stockToManage.FilmId);
			if (existingStock is null)
			{
				var stock = new Stock { FilmId = stockToManage.FilmId, Quantity = stockToManage.Quantity };
				_context.Stocks.Add(stock);
			}
			else
			{
				existingStock.Quantity = stockToManage.Quantity;
			}
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "")
		{
			var stocks = await (from film in _context.Films
								join stock in _context.Stocks
								on film.Id equals stock.FilmId
								into book_stock
								from bookStock in book_stock.DefaultIfEmpty()
								where string.IsNullOrWhiteSpace(sTerm) || film.FilmName.ToLower().Contains(sTerm.ToLower())
								select new StockDisplayModel
								{
									FilmId = film.Id,
									FilmName = film.FilmName,
									Quantity = bookStock == null ? 0 : bookStock.Quantity
								}
								).ToListAsync();
			return stocks;
		}

	}

	public interface IStockRepository
	{
		Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "");
		Task<Stock?> GetStockByBookId(int filmId);
		Task ManageStock(StockDTO stockToManage);
	}
}