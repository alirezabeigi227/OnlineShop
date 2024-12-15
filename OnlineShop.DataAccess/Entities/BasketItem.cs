using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Entities
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Quantity { get; set; } //تعداد

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int BasketId { get; set; }

        [ForeignKey(nameof(BasketId))]
        public Basket Basket { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
