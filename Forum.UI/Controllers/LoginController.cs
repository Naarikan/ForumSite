using Forum.BLL.ManagerServices.Abstract;
using Forum.UI.ExtensionClasses;
using Forum.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Forum.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppUserManager _userManager;

        public LoginController(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await _userManager.SignInAsync(loginModel.UserName, loginModel.Password);

            if (result.Succeeded)
            {

                var user = await _userManager.FindByNameAsync(loginModel.UserName);
                var roles = await _userManager.GetRolesAsync(user);


                string userRole = roles.FirstOrDefault();

                HttpContext.Session.SetObject("UserName", loginModel.UserName);
                HttpContext.Session.SetObject("UserRole", userRole);

                return RedirectToAction("MyProfile", "Profile");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Geçersiz Giriş.");
                return View(loginModel);
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
