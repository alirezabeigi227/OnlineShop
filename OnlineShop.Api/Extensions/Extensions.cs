//using Microsoft.AspNetCore.Http.Extensions;
//using OnlineShop.Api.Extensions;
//using OnlineShop.Api.Models;
//using OnlineShop.Business.Model.Dto;
//using OnlineShop.DataAccess.Entities;

//namespace OnlineShop.Extensions
//{
//    public static class Extensions
//    {

//        public static void CheckProductValid(this ProductDto productDto)
//        {
//            if (string.IsNullOrEmpty(productDto.Name))
//                throw new AppException(code: 402, message: "نام محصول معتبر نیست.");

//            if (productDto.Price > 1000)
//                throw new AppException(code: 402, message: "قیمت محصول باید بیشتر از 1000 باشد.");
//        }





//    }
//}
