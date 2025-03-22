namespace FilmShopMVC.Models.DTOs
{
	public class StockDisplayModel
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		public int Quantity { get; set; }
		public string? FilmName { get; set; }
	}
}