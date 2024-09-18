using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired()
                                     .HasMaxLength(150);

        builder.Property(e => e.Price).IsRequired()
                                      .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Stock).IsRequired();
    }
}

