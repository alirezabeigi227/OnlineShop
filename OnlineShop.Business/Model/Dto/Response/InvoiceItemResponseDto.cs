using OnlineShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto.Response
{
    public class InvoiceItemResponseDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal TotalPrice { get; set; }
        
        public int Count { get; set; } //تعداد

        public DateTime CreatedAt { get; set; }

        public int ProductId { get; internal set; }
    }
   
}
