using ProductCatalog.DAl;

namespace ProductCatalog.DAL;

public class UsersRepo : GenericRepo<User>, IUsersRepo
{
    private readonly ProductCatalogContext _context;

    public UsersRepo(ProductCatalogContext context) : base(context)
    {
        _context = context;
    }
}
