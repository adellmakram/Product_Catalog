namespace ProductCatalog.DAL;

public interface IProductsRepo : IGenericRepo<Product>
{
    IEnumerable<Product> GetAllWithCategory();
    IQueryable<Product> GetCurrentWithCategory();
    IQueryable<Product> FilterByCategory(int CategoryId);
    Product GetByIdWithUserAndCategory(int ProductId);
}
