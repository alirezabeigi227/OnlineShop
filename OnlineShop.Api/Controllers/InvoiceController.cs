using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Business.Model.Dto;
using OnlineShop.Business.Model.Dto.Request;
using OnlineShop.Business.Model.Dto.Response;
using OnlineShop.Business.Services;
using OnlineShop.DataAccess.Entities;
using System.Numerics;

namespace OnlineShop.Api.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        //[HttpPost("CreateInvoice")]

        //public async Task<ActionResult<InvoiceResponseDto>> CreateInvoice([FromBody] InvoiceDto invoiceDto ,[FromBody]InvoiceItemDto itemDto )
        //{

        //    if (invoiceDto == null)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await _invoiceService.CreateInvoice(invoiceDto);

        //    var invoiceResponseDto = new InvoiceResponseDto
        //    {
        //        Id = result.Id,
        //        Address = result.Address,
        //        Description = result.Description,
        //        Title = result.Title,

        //    };

        //    return Ok(invoiceResponseDto);

        //}



        [HttpPost()]
        public async Task<ActionResult<InvoiceItemRequestDto>> CreateInvoiceWithItems([FromBody] InvoiceRequestDto invoiceDto)
        {
            if (invoiceDto == null)
            {
                return BadRequest("Invoice data is required.");
            }
           
                // ایجاد فاکتور به همراه آیتم‌های آن
                var createdInvoice = await _invoiceService.CreateInvoice(invoiceDto);
               
            return Ok(createdInvoice);
          
        }

        [HttpGet("Invoice/{Id}")]
        public async Task<ActionResult<BasketItemDto>> GetInvoiceWithItems(int Id)
        {
            var result = await _invoiceService.GetInvoiceById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("AllInvoice/{Id}")]


        public async Task<ActionResult<Invoice>> GetAllInvoice()
        {
            var result = await _invoiceService.GetAllInvoiceAsync();
            return Ok(result);
        }

        [HttpGet("GetInvoice/{Id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int Id)
        {
            var result = await _invoiceService.GetInvoiceById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);


        }

        [HttpPut("put/{id}")]
        public async Task<ActionResult<Invoice>> UpdateInvoice(int id, [FromBody] InvoiceRequestDto invoiceDto)
        {

            var result = await _invoiceService.UpdateInvoiceAsync(id, invoiceDto);

            if (result == null)
            {
                return NotFound("صورت حساب مورد نظر پیدا نشد");
            }

            return Ok(result);
        }
        [HttpDelete("Delete/{Id}")]

        public async Task<ActionResult> DeleteInvoice(int id)
        {
            await _invoiceService.DeleteInvoiceAsync(id);
            return NoContent();
        }

        //[HttpPost("{invoiceId}/items")]
        //public async Task<ActionResult<InvoiceResponseDto>> AddInvoiceItem(int invoiceId, [FromBody] List<InvoiceItemDto> invoiceItemDto)
        //{
        //    if (invoiceItemDto == null || !invoiceItemDto.Any())
        //    {
        //        return BadRequest("لیست آیتم‌ها نمی‌تواند خالی باشد.");
        //    }


        //    var invoiceItem = await _invoiceService.AddInvoiceItemAsync(invoiceId, invoiceItemDto);

        //   //DTO 
        //    var invoiceItemResponseDto = new InvoiceResponseDto
        //    {
        //        Id = invoiceItem.Id,
        //        TotalPrice = invoiceItem.InvoiceItems.Sum(i => i.ToTalPrice),
        //        InvoiceItems = invoiceItem.InvoiceItems.Select(i => new InvoiceItemResponseDto
        //        {
        //            Id = i.Id,
        //            ProductName = i.ProductName,
        //            Count = i.Count,
        //            TotalPrice = i.ToTalPrice * i.Count
        //        }).ToList()
        //    };


        //    return Ok(invoiceItemResponseDto);

        //}

    }
}

