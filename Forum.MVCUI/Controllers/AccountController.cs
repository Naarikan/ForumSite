using FluentValidation.Results;
using Forum.BLL.ManagerServices.Abstract;
using Forum.MVCUI.Models.Login;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Forum.MVCUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserManager _userManager;

        public AccountController(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(/*new LoginModel()*/);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _userManager.SignInAsync(model.UserName, model.Password);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    //new Claim(ClaimTypes.NameIdentifier, model.UserName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties= new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),authProperties);

                return RedirectToAction("MyProfile", "Profile");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre hatalı.");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Entrance");
        }
    }
}
