using Microsoft.EntityFrameworkCore;
using OnlineShop.Business.Model.Dto;
using OnlineShop.Business.Model.Dto.Request;
using OnlineShop.DataAccess.DataContext;
using OnlineShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Business.Services
{
    public class BasketItemService
    {
        private readonly DatabaseContext _Context;

        public BasketItemService(DatabaseContext context)
        {
            _Context = context;
        }

        public async Task AddItemtoBasketAsync(int UserId, BasketItemRequestDto basketItemRequestDto)
        {
            // دریافت سبد خرید کاربر به همراه آیتم‌های آن به صورت ناهمزمان
            var basket = await _Context.Baskets
                .Include(b => b.BasketItems) // شامل کردن آیتم‌های سبد خرید
                .FirstOrDefaultAsync(b => b.UserId == UserId); // جستجوی سبد خرید بر اساس شناسه کاربر

            // اگر سبد خرید پیدا نشد، یک سبد جدید ایجاد می‌کنیم
            if (basket == null)
            {
                basket = new Basket
                {
                    UserId = UserId, // ایجاد سبد جدید با شناسه کاربر
                };
                _Context.Baskets.Add(basket); // افزودن سبد جدید به کانتکست
            }

            // جستجوی آیتم موجود در سبد خرید بر اساس شناسه محصول
            var Item = basket.BasketItems.FirstOrDefault(b => b.ProductId == basketItemRequestDto.ProductId);

            // افزودن آیتم جدید به سبد خرید
            basket.BasketItems.Add(new BasketItem
            {
                ProductId = basketItemRequestDto.ProductId, // شناسه محصول
                Quantity = basketItemRequestDto.Quantity, // تعداد محصول
            });
           

            // ذخیره تغییرات در پایگاه داده به صورت ناهمزمان
            await _Context.SaveChangesAsync();
         
        }
     
    }
}
