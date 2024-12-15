using OnlineShop.Business.Model.Dto.Request;
using OnlineShop.Business.Model.Dto.Response;
using OnlineShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto
{
    public class InvoiceRequestDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

       public DateTime InvoiceDate { get; set; }

       public int UserId { get; set; }

        public List<InvoiceItemRequestDto> InvoiceItems { get; set; }

    }
}
