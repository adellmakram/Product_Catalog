using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductCatalog.DAL;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.FName)
                  .HasMaxLength(10)
                  .IsRequired();

        builder.Property(e => e.LName)
              .HasMaxLength(10)
              .IsRequired();

        builder.Property(e => e.Email)
              .IsRequired()
              .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        builder.Property(e => e.Age)
            .IsRequired();
    }
}
