﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FilmShopMVC.Models
{
	[Table("CartDetail")]
	public class CartDetail
	{
		public int Id { get; set; }

		[Required]
		public int ShoppingCartId { get; set; }

		[Required]
		public int FilmId { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public double UnitPrice { get; set; }

		public Film film { get; set; }

		public ShoppingCart ShoppingCart { get; set; }
	}
}
