using System.ComponentModel.DataAnnotations.Schema;

namespace FilmShopMVC.Models
{
	[Table("Stock")]
	public class Stock
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		public int Quantity { get; set; }

		public Film? Film { get; set; }
	}
}
