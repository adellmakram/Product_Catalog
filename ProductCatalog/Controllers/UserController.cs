using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BL;
using Microsoft.AspNetCore.Http;


namespace ProductCatalog.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersManager _usersManager;

        public UserController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var register = await _usersManager.Register(userRegisterVM);

            if (!register.IsSuccess)
            {
                TempData["ErrorMessage"] = register.Message;
                return View();
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = _usersManager.Login(userLoginVM);
            var Data = await response;

            if(!Data.IsSuccess)
            {
                TempData["ErrorMessage"] = Data.Message;
                return View();
            }

            Response.Cookies.Append("UserId", Data.UserId);

            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _usersManager.Logout();
            return RedirectToAction("Login");
        } 
    }
}
