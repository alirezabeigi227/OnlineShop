using Microsoft.EntityFrameworkCore;
using OnlineShop.Business.Model.Dto;
using OnlineShop.DataAccess.DataContext;
using OnlineShop.DataAccess.Entities;

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
            var product = new Product
            {
              
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
             
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int Id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(Id);

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task <List<Product>> GetAllProductAsync()
        {
          
             var products = await _context.Products.ToListAsync();
            return products;
           
        }

        public async Task<Product?> GetProductByIdAsync(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id ==Id);
            return product;
        }

        public async Task DeleteProductAsync(int Id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}