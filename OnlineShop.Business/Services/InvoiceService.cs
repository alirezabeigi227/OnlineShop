using Microsoft.EntityFrameworkCore;
using OnlineShop.Business.Model.Dto;
using OnlineShop.DataAccess.DataContext;
using OnlineShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Services
{
    public class InvoiceService
    {
        private readonly DatabaseContext _Context;
        // private object invoiceRequestDto;

        public InvoiceService(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task<InvoiceRequestDto> CreateInvoice(InvoiceRequestDto invoiceDto)
        {

            var user = await _Context.Users.FindAsync(invoiceDto.UserId);
            if (user == null)
            {
                throw new Exception("کاربر پیدا نشد");

            }
            var invoice = new Invoice(invoiceDto.Title, invoiceDto.Description, invoiceDto.Address);
            //var invoice = new Invoice
            //{
            //    Title = invoiceDto.Title,
            //    Description = invoiceDto.Description,
            //    Address = invoiceDto.Address,
            //    InvoiceDate = invoiceDto.InvoiceDate,
            //    UserId = invoiceDto.UserId,
            //};
            _Context.Invoices.Add(invoice);


            await _Context.SaveChangesAsync();

            foreach (var itemDto in invoiceDto.InvoiceItems)
            {
                var invoiceItem = new InvoiceItem
                {
                    ProductId = itemDto.ProductId,
                    ProductName = itemDto.ProductName,
                    InvoiceId = invoice.Id
                };
                _Context.InvoicesItem.Add(invoiceItem);

            }

            await _Context.SaveChangesAsync();

            return invoiceDto;
        }

        public InvoiceDto? GetInvoiceWithItems(int Id)
        {
            var invoiceData = (from invoices in _Context.Invoices
                               where invoices.Id == Id
                               select invoices).SingleOrDefault();

            if (invoiceData == null)
            {
                return null;
            }
            var invoiceItems = (from invoiceItem in _Context.InvoicesItem
                                join invoices in _Context.Invoices
                                on invoiceItem.ProductId equals invoices.Id
                                where invoiceItem.InvoiceId == invoiceData.Id
                                select new InvoiceItemDto
                                {
                                    invoiceTitle = invoiceData.Title,
                                    invoiceAddress = invoiceData.Address,
                                    invoiceDescription = invoiceData.Description,
                                    invoiceId = invoiceData.Id,
                                    ProductPrice = invoiceItem.ProductId,
                                    ProductId = invoiceItem.ProductId,
                                    ProductName = invoiceItem.ProductName,



                                }).ToList();
            var result = new InvoiceDto
            {
                Id = invoiceData.Id,
                Items = invoiceItems
            };
            return result;
        }


        public async Task<List<Invoice>> GetAllInvoiceAsync()
        {
            var Invoices = await _Context.Invoices.ToListAsync();
            return Invoices;
        }

        public async Task<Invoice?> GetInvoiceById(int Id)
        {
            var Invoice = await _Context.Invoices.SingleOrDefaultAsync(x => x.Id == Id);
            return Invoice;
        }

        //UPDATE
        public async Task<Invoice?> UpdateInvoiceAsync(int Id, InvoiceRequestDto invoiceDto)
        {
            var Invoice = await _Context.Invoices.FirstOrDefaultAsync(x => x.Id == Id);
            if (Invoice == null) { return null; }

            Invoice.Updateinvoice(invoiceDto.Title, invoiceDto.Description, invoiceDto.Address);

            Invoice.Title = invoiceDto.Title;
            Invoice.Description = invoiceDto.Description;
            Invoice.Address = invoiceDto.Address;
            Invoice.InvoiceDate = invoiceDto.InvoiceDate;

            await _Context.SaveChangesAsync();
            return Invoice;
        }
        public async Task DeleteInvoiceAsync(int Id)
        {
            var Invoice = _Context.Invoices.SingleOrDefault(x => x.Id == Id);
            if (Invoice != null)
            {
                _Context.Invoices.Remove(Invoice);
                await _Context.SaveChangesAsync();
            }

        }


        //public async Task<Invoice> AddInvoiceItemAsync(int InvoiceId, List<InvoiceItemDto> invoiceItemDto)
        //{

        //    var invoice = await _Context.Invoices.Include(i => i.InvoiceItems).FirstOrDefaultAsync(i => i.Id == InvoiceId);
        //    if (invoice == null)
        //    {
        //        throw new Exception("فاکتور مورد نظر یافت نشد");
        //    }


        //    var invoiceItems = new List<InvoiceItem>();


        //    foreach (var itemDto in invoiceItemDto)
        //    {
        //        var invoiceItem = new InvoiceItem
        //        {
        //            Id = itemDto.Id, 
        //            ProductName = itemDto.ProductName,   
        //            Count = itemDto.Count,
        //            ToTalPrice = itemDto.TotalPrice * itemDto.Count, 
        //        };
        //        invoiceItems.Add(invoiceItem);
        //    }


        //    invoice.InvoiceItems.AddRange(invoiceItems);


        //    await _Context.SaveChangesAsync();


        //    return invoice;
        //}

    }


}


