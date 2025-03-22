using System.ComponentModel.DataAnnotations;

namespace FilmShopMVC.Models.DTOs
{
	public class StockDTO
	{
		public int FilmId { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
		public int Quantity { get; set; }
	}
}