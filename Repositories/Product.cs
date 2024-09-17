namespace Repositories;

public class Product
{
    public Product()
    {
        Name = default!;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
