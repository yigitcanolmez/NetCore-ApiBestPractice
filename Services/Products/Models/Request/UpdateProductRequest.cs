namespace Services.Products.Models.Request;

public record UpdateProductRequest(int Id, string Name, decimal Price, int Stock);