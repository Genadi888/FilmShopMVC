using FilmShopMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("OrderDetails")]
public class OrderDetail
{
	public int Id { get; set; }

	[Required]
	public int OrderId { get; set; }

	[Required]
	public int FilmId { get; set; }

	[Required]
	public int Quantity { get; set; }

	[Required]
	public double UnitPrice { get; set; }

	public Order Order { get; set; }

	public Film Film { get; set; }

}

