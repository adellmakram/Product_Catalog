using ProductCatalog.DAL;

namespace ProductCatalog.BL;

public class CategoriesManager : ICategoriesManager
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoriesManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<CategoryReadVM> GetAllCategories()
    {
        IEnumerable<Category>? categoriesFromDB = _unitOfWork.CategoriesRepo.GetAll();
        if (categoriesFromDB is null)
        {
            return new List<CategoryReadVM>();
        }

        IEnumerable<CategoryReadVM> categoryReadVMs = categoriesFromDB
            .Select(c => new CategoryReadVM
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
            });
        return categoryReadVMs;
        
    }
}
