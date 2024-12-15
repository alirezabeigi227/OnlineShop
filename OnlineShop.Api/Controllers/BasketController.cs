using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business.Model.Dto.Request;
using OnlineShop.Business.Services;
using OnlineShop.DataAccess.Entities;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketService _basketService;

        public BasketController(BasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpPost("CreateBsket and BasketItem")]

        public async Task<ActionResult<BasketItemRequestDto>> CreateBasketAndItem([FromBody] BasketRequestDto basketRequestDto)
        {
            if(basketRequestDto == null)
            {
                return BadRequest("basket data is required");
            }

            return Ok(await _basketService.CreateBasket(basketRequestDto));
        }
        [HttpGet("Get Basket")]
        public async Task<ActionResult<Basket>> GetBasketById(int Id)
        {
            var result = await _basketService.GetBasketById(Id);
            if(result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpPut("Update Basket")]
        public async Task<ActionResult<Basket>> UpdateBasket(int id , [FromBody] BasketRequestDto basketRequestDto)
        {
            var result  = await _basketService.UpdateBasketAsync(id, basketRequestDto);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("Delete Basket")]
        public async Task<ActionResult> DeleteBasket(int Id)
        {
            await _basketService.DeleteBasketAsync(Id);
            return NoContent();
        }
    }
}
