namespace usingHotReload.Models
{
    public class ProductService : IProductService
    {
        public List<string> GetProductNames()
        {
            return new()
            {
                "A","B","C"
            };
        }
    }

    public class FakeProductService : IProductService
    {
        public List<string> GetProductNames()
        {
            return new()
            {
                "X","Y","Z"
            };
        }
    }
}
