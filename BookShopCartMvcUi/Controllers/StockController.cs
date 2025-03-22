using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmShopMVC.Controllers
{
	[Authorize(Roles = nameof(Roles.Admin))]
	public class StockController : Controller
	{
		private readonly IStockRepository _stockRepo;

		public StockController(IStockRepository stockRepo)
		{
			_stockRepo = stockRepo;
		}

		public async Task<IActionResult> Index(string sTerm = "")
		{
			var stocks = await _stockRepo.GetStocks(sTerm);
			return View(stocks);
		}

		public async Task<IActionResult> ManangeStock(int filmId)
		{
			var existingStock = await _stockRepo.GetStockByBookId(filmId);
			var stock = new StockDTO
			{
				FilmId = filmId,
				Quantity = existingStock != null
			? existingStock.Quantity : 0
			};
			return View(stock);
		}

		[HttpPost]
		public async Task<IActionResult> ManangeStock(StockDTO stock)
		{
			if (!ModelState.IsValid)
				return View(stock);
			try
			{
				await _stockRepo.ManageStock(stock);
				TempData["successMessage"] = "Stock is updated successfully.";
			}
			catch (Exception ex)
			{
				TempData["errorMessage"] = "Something went wrong!!";
			}

			return RedirectToAction(nameof(Index));
		}
	}
}