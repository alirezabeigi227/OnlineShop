using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OnlineShop.Business.Model.Dto;
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

        [HttpGet("GetBasketWithItems")]
        public IActionResult GetBasketWithItems(int userId)
        {
            var result =  _basketService.GetBasketWithItems(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
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


        [HttpDelete("clear BasketItem")]
        public async Task<ActionResult> clearBasketItem(int UserId)
        {
            await _basketService.ClearBasketItemAsync(UserId);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetTotal(int basketId)
        {
            var totalPrice = await _basketService.GetBasketById(basketId).ConfigureAwait(false);
        
            return Ok(new { TotalPrice = totalPrice });
        }

    }
}
