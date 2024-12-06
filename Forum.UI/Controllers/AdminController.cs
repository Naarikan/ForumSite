using Forum.BLL.ManagerServices.Abstract;
using Forum.UI.Authorize;
using Forum.UI.ExtensionClasses;
using Forum.UI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forum.UI.Controllers
{

    public class AdminController : Controller
    {
        IAppUserManager _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public AdminController(IAppUserManager appUserManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = appUserManager;
            _roleManager = roleManager;
        }
        [RoleAuthorize("SAdmin", "NAdmin")]
        public async Task<IActionResult> Users()
        {
            var users = _userManager.GetActivesAsync().ToList();
            var userViewModels = new List<UserInfoModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserInfoModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = string.Join(", ", roles)
                });
            }

            return View(userViewModels);
        }

        [RoleAuthorize("SAdmin", "NAdmin")]
        public async Task<IActionResult> BannedUsers()
        {
            var users=_userManager.GetPassivesAsync().ToList();
            var userViewModels = new List<UserInfoModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserInfoModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = string.Join(", ", roles)
                });
            }

            return View(userViewModels);


        }



        [RoleAuthorize("SAdmin")]
        [HttpGet]
        public async Task<IActionResult> ChangeRole(int userId)
        {
            var user = await _userManager.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new ChangeRoleModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                CurrentRole = userRoles.FirstOrDefault(),
                SelectedRole = userRoles.FirstOrDefault()
            };

            ViewBag.Roles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            return View(model);
        }

        [RoleAuthorize("SAdmin")]
        [HttpPost]
        public async Task<IActionResult> ChangeRole(ChangeRoleModel model)
        {
            var user = await _userManager.FindAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user existing roles");
                    ViewBag.Roles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                    return View(model);
                }
            }

            var addResult = await _userManager.AddToRoleAsync(user, model.SelectedRole);
            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected role to user");
                ViewBag.Roles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                return View(model);
            }

            return RedirectToAction("Users");

        }
        [RoleAuthorize("SAdmin", "NAdmin")]
        public async Task<IActionResult> Banned(int id)
        {
            var user= await _userManager.FindAsync(id);
           await _userManager.DeleteAsync(user);
            return RedirectToAction("Users", "Admin");

        }
        [RoleAuthorize("SAdmin", "NAdmin")]
        public async Task<IActionResult> PermaBanned(int id)
        {
            var user = await _userManager.FindAsync(id);
            await _userManager.DestroyAsync(user);
            return RedirectToAction("Users", "Admin");

        }

        [RoleAuthorize("SAdmin", "NAdmin")]
        public async Task<IActionResult> RemoveBan(int id)
        {
            var user = await _userManager.FindAsync(id); 
            await _userManager.UpdateUser(user);
            return RedirectToAction("BannedUsers", "Admin");

        }

    }
}
