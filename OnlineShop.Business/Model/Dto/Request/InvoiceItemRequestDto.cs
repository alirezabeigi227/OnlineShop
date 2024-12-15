using OnlineShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto.Request
{
    public class InvoiceItemRequestDto
    {
        public string ProductName { get; set; }

        public decimal TotalPrice { get; set; }

        public long Fee { get; set; }

        public int Count { get; set; } //تعداد

        public int ProductId { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
