namespace ProductCatalog.BL;

public interface IProductsManager
{
    IEnumerable<ProductsReadVM> GetAllProducts();
    IEnumerable<ProductsReadVM> GetCurrentProducts();
    IEnumerable<ProductsReadVM> GetFilteredProducts(int categoryId);
    void AddProduct(ProductsAddVM productVM, string id);
    ProductDetailsVM GetDetails(int productId);
    void DeleteProduct(int productId);
    ProductEditVM GetToEditProduct(int productId);
    void EditProduct(ProductEditVM productEditVM);
}
