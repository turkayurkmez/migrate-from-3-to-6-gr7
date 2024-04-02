
namespace usingMinimal.Services
{
    public interface IProductService
    {
        int Create(CreateProductRequest request);
        ProductDisplayResponse GetProduct(int id);
        List<ProductDisplayResponse> GetProducts();
        List<ProductDisplayResponse> Search(string name);
    }
}