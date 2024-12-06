using Microsoft.AspNetCore.Identity;
using Forum.UI.Models.User;
using Forum.UI.ValidationRules.User;
using Microsoft.AspNetCore.Mvc;
using Forum.Entities.Models;

namespace Forum.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RegisterController(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Form(RegisterModel registerModel)
        {
            ModelState.Clear();
            RegisterValidator rv = new RegisterValidator();
            FluentValidation.Results.ValidationResult results = rv.Validate(registerModel);

            if (results.IsValid)
            {
                var user = new AppUser
                {
                    UserName = registerModel.UserName,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    
                    if (!await _roleManager.RoleExistsAsync("User"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole<int> { Name = "User" });
                    }
                    await _userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }

            return View(registerModel);
        }
    }
}
