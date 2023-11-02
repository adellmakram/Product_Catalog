using ProductCatalog.DAL;

namespace ProductCatalog.BL;

public class ProductsManager : IProductsManager
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductsManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<ProductsReadVM> GetAllProducts()
    {
        IEnumerable<Product>? productsFromDB = _unitOfWork.ProductsRepo.GetAllWithCategory();

        if(productsFromDB is null)
        {
            return new List<ProductsReadVM>();
        }

        IEnumerable<ProductsReadVM> productsVM = productsFromDB
            .Select(p => new ProductsReadVM
            {
                ProductId = p.ProductId,
                productName = p.productName,
                Price = p.Price,
                Category = p.Category.CategoryName
            });
        return productsVM;
    }

    public IEnumerable<ProductsReadVM> GetCurrentProducts()
    {
        IQueryable<Product>? productsFromDB = _unitOfWork.ProductsRepo.GetCurrentWithCategory();

        if (productsFromDB is null)
        {
            return new List<ProductsReadVM>();
        }

        IEnumerable<ProductsReadVM> productsVM = productsFromDB
            .Select(p => new ProductsReadVM
            {
                ProductId = p.ProductId,
                productName = p.productName,
                Price = p.Price,
                Category = p.Category.CategoryName
            });
        return productsVM;
    }

    public IEnumerable<ProductsReadVM> GetFilteredProducts(int categoryId)
    {
        IQueryable<Product>? productsFromDB = _unitOfWork.ProductsRepo.FilterByCategory(categoryId);

        if (productsFromDB is null)
        {
            return new List<ProductsReadVM>();
        }

        IEnumerable<ProductsReadVM> productsVM = productsFromDB
            .Select(p => new ProductsReadVM
            {
                ProductId = p.ProductId,
                productName = p.productName,
                Price = p.Price,
                Category = p.Category.CategoryName
            });
        return productsVM;
    }

    public void AddProduct(ProductsAddVM productVM, string id)
    {
        Product product = new Product
        {
            productName = productVM.productName,
            CreationDate = DateTime.Now,
            StartDate = productVM.StartDate,
            Duration = productVM.Duration,
            Price = productVM.Price,
            CategoryId = productVM.CategoryId,
            CreatedBy = id
        };

        _unitOfWork.ProductsRepo.Add(product);
        _unitOfWork.SaveChanges();
    }

    public ProductDetailsVM GetDetails(int productId)
    {
        Product? productFromDB = _unitOfWork.ProductsRepo.GetByIdWithUserAndCategory(productId);

        if(productFromDB is null)
        {
            return new ProductDetailsVM();
        }

        ProductDetailsVM productDetailsVM = new ProductDetailsVM
        {
            ProductId = productFromDB.ProductId,
            productName = productFromDB.productName,
            Price = productFromDB.Price,
            CreationDate = productFromDB.CreationDate,
            StartDate = productFromDB.StartDate,
            Duration = productFromDB.Duration.ToString() + " Days",
            CreatedBy = productFromDB.User.FName + " " + productFromDB.User.LName,
            Category = productFromDB.Category.CategoryName
        };
        return productDetailsVM;
    }

    public void DeleteProduct(int productId)
    {
        Product? productFromDB = _unitOfWork.ProductsRepo.GetById(productId);

        if(productFromDB is null)
        {
            return;
        }

        _unitOfWork.ProductsRepo.Delete(productFromDB);
        _unitOfWork.SaveChanges();
    }

    public ProductEditVM GetToEditProduct(int productId)
    {
        Product? productFromDB = _unitOfWork.ProductsRepo.GetByIdWithUserAndCategory(productId);

        if(productFromDB is null)
        {
            return new ProductEditVM();
        }

        ProductEditVM productEditVM = new ProductEditVM
        {
            ProductId = productFromDB.ProductId,
            productName = productFromDB.productName,
            Price = productFromDB.Price,
            StartDate = productFromDB.StartDate,
            Duration = productFromDB.Duration,
            CategoryId = productFromDB.CategoryId
        };

        return productEditVM;
    }

    public void EditProduct(ProductEditVM productEditVM)
    {
        Product? productFromDb = _unitOfWork.ProductsRepo.GetById(productEditVM.ProductId);

        if(productFromDb is null)
        {
            return;
        }

        productFromDb.productName = productEditVM.productName;
        productFromDb.Price = productEditVM.Price;
        productFromDb.StartDate = productEditVM.StartDate;
        productFromDb.Duration = productEditVM.Duration;
        productFromDb.CategoryId = productEditVM.CategoryId;

        _unitOfWork.SaveChanges();

    }

}
