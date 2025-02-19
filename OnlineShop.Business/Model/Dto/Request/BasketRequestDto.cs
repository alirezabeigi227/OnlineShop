using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Model.Dto.Request
{
    public class BasketRequestDto
    {
        //public int Id { get; set; }

        public int UserId { get; set; }

     public List<BasketItemRequestDto> basketItems { get; set; }
    }
}
