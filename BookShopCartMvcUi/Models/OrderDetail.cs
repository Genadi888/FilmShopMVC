using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmShopMVC.Models
{
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
}
