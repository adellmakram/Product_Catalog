using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.DAL;

namespace ProductCatalog.DAl;

public class ProductCatalogContext : IdentityDbContext<User>
{
    //public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    public ProductCatalogContext(DbContextOptions options)
        :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new ProductsConfig().Configure(modelBuilder.Entity<Product>());

        new UserConfig().Configure(modelBuilder.Entity<User>());

        new CategoryConfig().Configure(modelBuilder.Entity<Category>());

        modelBuilder.Entity<Category>().HasData(CategorySeeding.categoryList);

    }
}
