using Microsoft.EntityFrameworkCore;
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
    public class BasketService
    {
        private readonly DatabaseContext _Context;

        public BasketService(DatabaseContext context)
        {
            _Context = context;
        }
        public async Task<BasketRequestDto> CreateBasket(BasketRequestDto basketRequestDto)
        {
            var user = await _Context.Users.FindAsync(basketRequestDto.UserId);

            if (user == null)
            {
                throw new Exception("کاربر یافت نشد");
            }

            var basket = new Basket
            {
                Id = basketRequestDto.Id,
                UserId = basketRequestDto.UserId,
            };
            _Context.Baskets.Add(basket);

            await _Context.SaveChangesAsync();


            foreach (var ItemDto in basketRequestDto.basketItems)
            {
                var basketItem = new BasketItem
                {
                    BasketId = ItemDto.Id,
                    Name = ItemDto.Name,
                    Quantity = ItemDto.Quantity,
                    Price = ItemDto.Price,
                    ProductId = ItemDto.ProductId,
                    Description = ItemDto.Description,

                };
                _Context.BasketItems.Add(basketItem);
                await _Context.SaveChangesAsync();
            }
            
            return basketRequestDto;
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
    }
}
