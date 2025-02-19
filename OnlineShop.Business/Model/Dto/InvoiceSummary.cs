using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        public List<InvoiceItemDto> Items { get; set; } = [];
    }

    public class InvoiceItemDto
    {
        public int invoiceId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
     


        public decimal ProductPrice { get; set; }

        /// <summary>
        /// /////////////////////
        /// </summary>
        public string invoiceTitle { get; set; }

        public string invoiceDescription { get; set; }

        public string invoiceAddress { get; set; }

    }
}
