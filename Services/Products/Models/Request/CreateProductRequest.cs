namespace Services.Products.Models.Request;

public record CreateProductRequest(string Name, decimal Price, int Stock);
