using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business.Model.Dto.Request;
using OnlineShop.Business.Services;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly BasketItemService _basketItemService;

        public BasketItemController(BasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpPost("{userId}/add")]
        public async Task<IActionResult> AddItemToBasket(int userId,[FromBody] BasketItemRequestDto basketItemRequestDto)
        {
    
            // فراخوانی سرویس برای افزودن آیتم به سبد خرید
            await _basketItemService.AddItemtoBasketAsync(userId, basketItemRequestDto);

            return Ok("آیتم با موفقیت افزوده شد.");
        }
       
       
    }
}
