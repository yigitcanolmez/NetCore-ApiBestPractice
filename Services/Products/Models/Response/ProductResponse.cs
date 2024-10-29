namespace Services.Products.Models.Response;

public record ProductResponse(int Id,
                              string Name,
                              decimal Price,
                              int Stock);

 