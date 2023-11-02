using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ProductCatalog.DAL;

public class ProductsConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.productName)
                  .HasMaxLength(100)
                  .IsRequired();

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.Duration)
                .IsRequired();

            builder.HasOne(e => e.User)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.CreatedBy);

            builder.HasOne(e => e.Category)
                    .WithMany(e => e.products)
                    .HasForeignKey(e => e.CategoryId);

    }
}
