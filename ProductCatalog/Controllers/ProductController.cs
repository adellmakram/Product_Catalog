
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog.BL;

namespace ProductCatalog.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsManager _productsManager;
        private readonly ICategoriesManager _categoriesManager;
        public ProductController(IProductsManager productsManager, ICategoriesManager categoriesManager)
        {
            _productsManager = productsManager;
            _categoriesManager = categoriesManager;
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            ViewData["Categories"] = _categoriesManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();

            IEnumerable<ProductsReadVM> products = _productsManager.GetAllProducts();
            return View(products);
        }

        [Authorize]
        [HttpGet]
        public IActionResult CurrentProduct()
        {
            ViewData["Categories"] = _categoriesManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();

            IEnumerable<ProductsReadVM> products = _productsManager.GetCurrentProducts();
            return View(products);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewData["Categories"] = _categoriesManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();

            return View();
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult AddProduct(ProductsAddVM productsAddVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = _categoriesManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();
                return View();
            }

            var token = Request.Cookies["UserId"];

            _productsManager.AddProduct(productsAddVM, token);
            return RedirectToAction("Index", "Product");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            ProductDetailsVM productDetailsVM = _productsManager.GetDetails(id);
            return View(productDetailsVM);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productsManager.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductEditVM productEditVM = _productsManager.GetToEditProduct(id);

            ViewData["Categories"] = _categoriesManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();

            return View(productEditVM);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult Edit(ProductEditVM productEditVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = _categoriesManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();
                return View();
            }

            _productsManager.EditProduct(productEditVM);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult ProductFilter(int id)
        {
            ViewData["Categories"] = _categoriesManager.GetAllCategories()
                .Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString()))
                .ToList();

            IEnumerable<ProductsReadVM> FilteredProducts = _productsManager.GetFilteredProducts(id);

            return View(FilteredProducts);
        }
    }
}
