using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto.Request
{
    public class BasketItemRequestDto
    {
        //public int Id { get; set; }


        public int Quantity { get; set; } //تعداد


        //public int BasketId { get; set; }

        public int ProductId { get; set; }
    }
}
