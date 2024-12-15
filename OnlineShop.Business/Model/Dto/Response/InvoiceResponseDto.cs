using OnlineShop.Business.Model.Dto.Response;
using OnlineShop.DataAccess.Entities;

namespace OnlineShop.Business.Services
{
    public class InvoiceResponseDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }
       

    }
}