using Forum.MVCUI.Models.AppUser;
using Forum.MVCUI.ValidationRules;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Forum.BLL.ManagerServices.Abstract;
using Forum.Entities.Models;

namespace Forum.MVCUI.Controllers
{
    public class AppUserController : Controller
    {
        IAppUserManager _appUserManager;

        public AppUserController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        public  IActionResult Index()
        {
            var users = _appUserManager.GetAllAsync();
            var model = new List<ListAppUserModel>();

            foreach (var user in users)
            {
                model.Add(new ListAppUserModel
                {
                    UserName = user.UserName,
                    Email = user.Email
                });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateUserScreen()
        {
            // Boş bir model nesnesi oluşturup view'a gönderiyoruz
            var model = new CreateUserModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserScreen(CreateUserModel createUserModel)
        {
			ModelState.Clear();
			CreateUserValidator validator = new CreateUserValidator();
            ValidationResult results = validator.Validate(createUserModel);

            if (results.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = createUserModel.UserName,
                    Email = createUserModel.Email,
                    //PhoneNumber = createUserModel.PhoneNumber,
                    PasswordHash = createUserModel.Password
                };
                await _appUserManager.CreateUserAsync(appUser);
                return RedirectToAction("Login","Entrance");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(createUserModel);
            }
        }
    }
}
