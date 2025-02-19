using Microsoft.EntityFrameworkCore;
using OnlineShop.Business.Model.Dto;
using OnlineShop.Business.Model.Dto.Response;
using OnlineShop.DataAccess.DataContext;
using OnlineShop.DataAccess.Entities;
using System.Diagnostics;

namespace OnlineShop.Business.Services
{
    public class ProductService
    {
        private readonly DatabaseContext _context;
        private object _productRepository;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }



        public async Task<Product> CreateProduct(ProductDto productDto)
        {
            //if (string.IsNullOrWhiteSpace(productDto.Name))
            //{
            //    throw new Exception("لطفا اسم را وارد کنید");
            //}

            //if (productDto.Price <= 1000)
            //{
            //    throw new Exception("قیمت را درست وارد کنید");
            //}



            var p = new Product(productDto.Name, productDto.Description, productDto.Price);
           
            p.SetPrice(52000);

            _context.Products.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }


        //public async Task<ProductDto> UpdateProductAsync(int Id, ProductDto productDto)
        //{
        //    //if (string.IsNullOrWhiteSpace(productDto.Name))
        //    //{
        //    //    throw new Exception("لطفا اسم را وارد کنید");
        //    //}

        //    //if (productDto.Price <= 1000)
        //    //{
        //    //    throw new Exception("قیمت را درست وارد کنید");
        //    //}

        //    var product = await _context.Products.FindAsync(Id);        

        //    product.Name = productDto.Name;
        //    product.Price = productDto.Price;
        //    product.Description = productDto.Description;



        //    await _context.SaveChangesAsync();
        //    return productDto;
        //}

        public async Task<ProductDto?> UpdateProductAsync(int Id, ProductDto productDto)
        {

            var product = await _context.Products.FindAsync(Id);
            if (product == null) { 
                return null; 
            }


            product.Updateproduct(productDto.Name, productDto.Description, productDto.Price);

            _context.Update(product);
            await _context.SaveChangesAsync();


            var response = new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            return response;
        }




        public async Task<List<Product>> GetAllProductAsync()
        {

            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductByIdAsync(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Guid.Empty);
            return product;
        }


        public async Task DeleteProductAsync(int Id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == Guid.Empty);
            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

    }
}
