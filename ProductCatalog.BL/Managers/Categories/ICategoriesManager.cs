namespace ProductCatalog.BL;

public interface ICategoriesManager
{
    IEnumerable<CategoryReadVM> GetAllCategories();
}
