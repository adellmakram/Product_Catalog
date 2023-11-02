using Microsoft.EntityFrameworkCore;
using ProductCatalog.DAl;

namespace ProductCatalog.DAL;

public class CategoriesRepo : GenericRepo<Category>, ICategoriesRepo
{
    private readonly ProductCatalogContext _context;

    public CategoriesRepo(ProductCatalogContext context) : base(context)
    {
        _context = context;
    }
}
