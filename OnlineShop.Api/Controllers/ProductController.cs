using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business.Model.Dto;
using OnlineShop.Business.Services;
using OnlineShop.DataAccess.Entities;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _ProductService;

        public ProductController(ProductService productService)
        {
            _ProductService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }
            var result = await _ProductService.CreateProduct(productDto);
            return Ok(result);
        }

        [HttpGet("AllProduct")]
        public async Task<ActionResult<Product>> GetProduct()
        {
            var result = await _ProductService.GetAllProductAsync();
            return Ok(result);
        }

        [HttpGet("GetProduct")]
        public async Task<ActionResult<Product>> GetProductById(int Id)
        {
            var result  =await _ProductService.GetProductByIdAsync(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id} UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var updatedProduct = await _ProductService.UpdateProductAsync(id, productDto);

            if (updatedProduct == null)
            {
                return NotFound("محصول مورد نظر پیدا نشد");
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
           await _ProductService.DeleteProductAsync(Id);
            return NoContent();
        }
    }
}