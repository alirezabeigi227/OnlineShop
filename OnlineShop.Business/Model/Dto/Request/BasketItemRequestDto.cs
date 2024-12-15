using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto.Request
{
    public class BasketItemRequestDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Quantity { get; set; } //تعداد

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int BasketId { get; set; }

        public int ProductId { get; set; }
    }
}
