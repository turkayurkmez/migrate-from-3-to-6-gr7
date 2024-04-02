using NewFeaturesOfAspNETSix.Models;

namespace NewFeaturesOfAspNETSix.Services
{
    public class ProductService : IProductService
    {
        public List<ProductInfoResponse> GetProducts()
        {
            return new()
           {
               new(1, "Güneş Gözlüğü",750),
               new(1, "Şapka",250),
               new(1, "Şort",400)
           };
        }

        public override string ToString()
        {
            return "ProductService instance'ı";
        }
    }
}
