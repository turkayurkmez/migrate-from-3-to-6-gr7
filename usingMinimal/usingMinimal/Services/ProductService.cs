namespace usingMinimal.Services
{
    public class ProductService : IProductService
    {
        private List<ProductDisplayResponse> displayResponses = new()
        {
             new(1,"Ürün 1", "Ürün 1 Açıklama",100),
             new(2,"Ürün 2", "Ürün 2 Açıklama",150),
             new(3,"Ürün 3", "Ürün 3 Açıklama",200),

        };

        public ProductDisplayResponse GetProduct(int id)
        {
            return displayResponses.FirstOrDefault(p => p.Id == id);
        }

        public List<ProductDisplayResponse> GetProducts()
        {
            return displayResponses;
        }

        public List<ProductDisplayResponse> Search(string name)
        {
            return displayResponses.Where(p => p.Name.Contains(name)).ToList();
        }

        public int Create(CreateProductRequest request)
        {
            var lastId = displayResponses.Last().Id + 1;
            var product = new ProductDisplayResponse
            (
                 Id: lastId,
                 Name: request.Name,
                 Description: request.Description,
                 Price: request.Price

            );

            displayResponses.Add(product);
            return lastId;
        }
    }
}
