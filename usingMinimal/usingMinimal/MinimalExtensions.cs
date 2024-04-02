using usingMinimal.Services;

namespace usingMinimal
{
    public static class MinimalExtensions
    {
        public static RouteHandlerBuilder GetProducts(this WebApplication app, string url, IProductService productService)
        {
            return app.MapGet("/products", (IProductService productService) =>
             {
                 var products = productService.GetProducts();
                 return Results.Ok(products);
             });
        }
    }
}
