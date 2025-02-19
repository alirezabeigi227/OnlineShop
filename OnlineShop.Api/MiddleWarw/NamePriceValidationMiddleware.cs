using System.Buffers;

namespace OnlineShop.Api.MiddleWarw
{
    public  class NamePriceValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public NamePriceValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {             
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400; 
                 await context.Response.WriteAsJsonAsync($"Error: {ex.Message}");
                
            }
        }
    }
}

