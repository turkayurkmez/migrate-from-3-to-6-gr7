namespace usingMinimal
{
    public record ProductDisplayResponse(int Id, string Name, string? Description, double? Price);
    public record CreateProductRequest(string Name, string? Description, double? Price);
}
