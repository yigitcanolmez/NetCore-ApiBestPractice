using FluentValidation;

namespace Services.Products.Models.Request;

public record CreateProductRequest(string Name, decimal Price, int Stock);

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .Length(4, 12);

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .LessThan(500);
        
        RuleFor(x => x.Stock)
            .InclusiveBetween(5,500);
    }
}