namespace ProductCatalog.DAL;

public interface IUnitOfWork
{
    public IProductsRepo ProductsRepo { get; }
    public IUsersRepo UsersRepo { get; }
    public ICategoriesRepo CategoriesRepo { get; }
    int SaveChanges();
}
