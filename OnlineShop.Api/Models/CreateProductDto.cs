﻿
namespace OnlineShop.Api.Models
{
    public class productValid
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

       
    }

    public class UpdateProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
