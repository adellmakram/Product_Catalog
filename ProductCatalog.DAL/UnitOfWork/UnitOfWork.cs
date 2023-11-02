using ProductCatalog.DAl;

namespace ProductCatalog.DAL;

public class UnitOfWork : IUnitOfWork
{

    public IProductsRepo ProductsRepo { get; }

    public IUsersRepo UsersRepo { get; }

    public ICategoriesRepo CategoriesRepo { get; }

    private readonly ProductCatalogContext _context;

    public UnitOfWork(ProductCatalogContext context,
        IProductsRepo productsRepo,
        IUsersRepo usersRepo,
        ICategoriesRepo categoriesRepo)
    {
        _context = context;
        ProductsRepo = productsRepo;
        UsersRepo = usersRepo;
        CategoriesRepo = categoriesRepo;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
