using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using OnlineShop.Api.MiddleWarw;
using OnlineShop.Business.Services;
using OnlineShop.DataAccess.DataContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Services for DI
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<BasketItemService>();

//MiddleWare
//public async void Configrue(IApplicationBuilder app)
//{
//    app.UseMiddleware<MyGroupCollectionAttribute>();
//    app.UseMvc();
//    app.UseRouting();
//    app.UseEndpoints(endpoints = >{

//        Endpoint.MapGet();
//        await ContextBoundObject.ResponseWriteAsync("");
//    });
//}



//database
builder.Services.AddDbContext<DatabaseContext>(
          p => p.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopDb"),
            b => b.MigrationsAssembly("OnlineShop.Api")));


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<NamePriceValidationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




