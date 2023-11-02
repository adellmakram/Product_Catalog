using Microsoft.EntityFrameworkCore;
using ProductCatalog.DAl;

namespace ProductCatalog.DAL;

public class ProductsRepo : GenericRepo<Product>, IProductsRepo
{
    private readonly ProductCatalogContext _context;

    public ProductsRepo(ProductCatalogContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<Product> FilterByCategory(int CategoryId)
    {
        return _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == CategoryId);
    }

    public IEnumerable<Product> GetAllWithCategory()
    {
        return _context.Products
                .Include(p => p.Category)
                .AsNoTracking();
    }

    public Product? GetByIdWithUserAndCategory(int ProductId)
    {
        return _context.Products
            .Include(p => p.Category)
            .Include(p => p.User)
            .FirstOrDefault(d => d.ProductId == ProductId);
    }

    public IQueryable<Product> GetCurrentWithCategory()
    {
        return _context.Products
                .Include(p => p.Category)
                .Where(p => p.StartDate.AddDays(p.Duration) > DateTime.Now)
                .AsNoTracking();
    }
}
