using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
       

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoicesItem { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Invoices)
            //    .WithOne(i => i.User);
            

            //modelBuilder.Entity<Invoice>()
            //    .HasMany(i => i.InvoiceItems)
            //    .WithOne(ii => ii.Invoice);

            //modelBuilder.Entity<InvoiceItem>()
            //    .HasMany(ii => ii.Products)
            //    .WithOne(p => p.InvoiceItem)
            //    .HasForeignKey(p =>p .Id);

            //modelBuilder.Entity<Basket>()
            //    .HasMany(b => b.Products)
            //.WithOne(p =>p.Basket)
            //.HasForeignKey(p =>p.Id);
        }

    }
}
