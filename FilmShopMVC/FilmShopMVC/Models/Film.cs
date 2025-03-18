using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FilmShopMVC.Models
{
	[Table("Film")]
	public class Film
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string? FilmName { get; set; }

		[Required]
		[MaxLength(200)]
		public string? DirectorName { get; set; }

		[Required]
		public double Price { get; set; }

		public string? Image { get; set; }

		[Required]
		public int GenreId { get; set; }

		public Genre Genre { get; set; }

		public List<OrderDetail> CartDetail { get; set; }

		public Stock Stock { get; set; }

		[NotMapped]
		public string GenreName { get; set; }

		[NotMapped]
		public int Quantity { get; set; }

	}
}
