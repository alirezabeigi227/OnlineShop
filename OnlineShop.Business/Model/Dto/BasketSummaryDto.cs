using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto
{
    public class BasketDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<BasketItemDto> Items { get; set; } = [];

    }
    public class BasketItemDto
    {
        public int BasketId { get; set; }
     
        public int InvoiceItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
       
        public decimal ProductPrice { get; set; }
    }
}
