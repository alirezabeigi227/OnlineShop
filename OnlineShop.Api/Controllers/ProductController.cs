using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Models;
using OnlineShop.Business.Model.Dto;
using OnlineShop.Business.Model.Dto.Request;
using OnlineShop.Business.Services;
using OnlineShop.DataAccess.Entities;


namespace OnlineShop.Api.Controllers
{
    [Route("Api/V1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _ProductService;

        public ProductController(ProductService productService)
        {
            _ProductService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto productDto)
        {


            if (productDto == null)
            {
                return BadRequest();
            }
            var result = await _ProductService.CreateProduct(productDto);
            return Ok(result);

            
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProduct()
        {
            var result = await _ProductService.GetAllProductAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] int id)
        {
            var result  =await _ProductService.GetProductByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromRoute]int id, [FromBody] ProductDto productDto )
        {
            //if (id != productDto)
            //{
            //    return BadRequest();
            //}
            
                var updatedProduct = await _ProductService.UpdateProductAsync(id, productDto);

            if (updatedProduct == null)
            {
                return NotFound("محصول مورد نظر پیدا نشد");
            }

            return Ok(updatedProduct);     
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
           await _ProductService.DeleteProductAsync(id);
            return NoContent();
        }

      
    }
}