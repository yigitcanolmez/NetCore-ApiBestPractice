namespace Services.Products.Models.Request;

public record UpdateProductRequest(string Name, decimal Price, int Stock);