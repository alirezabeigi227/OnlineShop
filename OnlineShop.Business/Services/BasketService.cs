using Microsoft.EntityFrameworkCore;
using OnlineShop.Business.Model.Dto;
using OnlineShop.Business.Model.Dto.Request;
using OnlineShop.DataAccess.DataContext;
using OnlineShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Services
{
    public class BasketService
    {
        private readonly DatabaseContext _Context;

        public BasketService(DatabaseContext context)
        {
            _Context = context;
        }
        public async Task<BasketRequestDto> CreateBasket(BasketRequestDto basketRequestDto)
        {
            // جستجوی کاربر با شناسه مشخص از دیتابیس
            var user = await _Context.Users.FindAsync(basketRequestDto.UserId);

            // بررسی وجود کاربر، اگر کاربر یافت نشود، استثنا پرتاب می‌شود
            if (user == null)
            {
                throw new Exception("کاربر یافت نشد");
            }

            var basket = await _Context.Baskets
                .FirstOrDefaultAsync(b =>b.UserId == basketRequestDto.UserId);

            if (basket == null)
            {
                basket = new Basket
                {

                    UserId = basketRequestDto.UserId,
                };
                _Context.Baskets.Add(basket);

                await _Context.SaveChangesAsync();
            }

           

            // افزودن اقلام سبد خرید به دیتابیس
            foreach (var ItemDto in basketRequestDto.basketItems)
            {
                // ایجاد یک شیء جدید از نوع BasketItem


                var basketItem = new BasketItem
                {
                    BasketId = basket.Id,                  // شناسه سبد خرید
                    Quantity = ItemDto.Quantity,            // تعداد محصول
                    ProductId = ItemDto.ProductId,          // شناسه محصول
                };

                // افزودن قلم سبد خرید به مجموعه اقلام سبد
                _Context.BasketItems.Add(basketItem);

                // ذخیره تغییرات برای هر قلم سبد خرید
                await _Context.SaveChangesAsync();
            }

            // برگرداندن شیء BasketRequestDto
            return basketRequestDto;
        }

        public async Task< BasketDto?> GetBasketWithItems(int userId)
        {
            // جستجوی سبد خرید کاربر با شناسه مشخص
            var basketData = (from baskets in _Context.Baskets
                              where baskets.UserId == userId
                              select baskets).SingleOrDefault();

            // اگر سبد خرید پیدا نشود، null برمی‌گرداند
            if (basketData == null) return null;

            // جستجوی اقلام سبد خرید مرتبط با سبد خرید پیدا شده
            var basketItems = (from basketItem in _Context.BasketItems
                               join products in _Context.Products
                               on basketItem.ProductId equals products.Id
                               where basketItem.BasketId == basketData.Id
                               select new BasketItemDto
                               {
                                   BasketId = basketData.Id,           // شناسه سبد خرید
                                   InvoiceItemId = basketItem.Id,       // شناسه قلم سبد خرید
                                   ProductId = products.Id,            // شناسه محصول
                                   ProductName = products.Name,         // نام محصول
                                   Quantity = basketItem.Quantity,      // تعداد محصول
                                   ProductPrice = products.Price        // قیمت محصول
                               }).ToList(); // تبدیل نتیجه به لیست

            // ایجاد شیء نهایی از نوع BasketDto
            var result = new BasketDto
            {
                Id = basketData.Id,                    // شناسه سبد خرید
                UserId = basketData.UserId,            // شناسه کاربر
                Items = basketItems                     // لیست اقلام سبد خرید
            };

            // برگرداندن شیء BasketDto
            return result;
        }

        public async Task<Basket?> GetBasketById(int Id)
        {
            var Basket = await _Context.Baskets.FirstOrDefaultAsync(b => b.Id == Id);
            return Basket;
        }
        

        public async Task<Basket?> UpdateBasketAsync(int Id, BasketRequestDto basketRequestDto)
        {
            var Basket = await _Context.Baskets.FirstOrDefaultAsync(b => b.Id == Id);
            if (Basket == null)
            {
                return null;
            }
            Basket.UserId = basketRequestDto.UserId;

            await _Context.SaveChangesAsync();
            return Basket;
        }

        public async Task DeleteBasketAsync(int Id)
        {
            var Basket = await _Context.Baskets.SingleOrDefaultAsync(b => b.Id == Id);
            if (Basket != null)
            {
                _Context.Baskets.Remove(Basket);
                await _Context.SaveChangesAsync();
                
            }
        }

        public async Task ClearBasketItemAsync(int UserId)
        {
            var basket = await _Context.Baskets
          .Include(b => b.BasketItems) 
          .FirstOrDefaultAsync(b => b.UserId == UserId);
            if (basket == null)
            {
                throw new Exception("سبد مورد نظر یافت نشد");
            }
            _Context.Baskets.Remove(basket);

            await _Context.SaveChangesAsync();

        }
        public async Task GetTotalPrice(int basketId)
        {
            var basket = await _Context.Baskets
          .Include(b => b.BasketItems)
          .ThenInclude(bi => bi.Product)
          .FirstOrDefaultAsync(b => b.Id == basketId);

            if(basket == null)
            {
                throw new Exception("سبد مورد نظر یافت نشد");
            }

            decimal totalPrice = 10;
            foreach(var basketItem in basket.BasketItems) {

                // decimal price  = basketItem.Price > 0 ? basketItem.Price : basketItem.Product.Price;
                totalPrice += basketItem.Quantity * totalPrice ;
            }

        }

        public Task GetBasketByIdAsync(int basketId)
        {
            throw new NotImplementedException();
        }
    }
}