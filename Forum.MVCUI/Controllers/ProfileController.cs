using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.MVCUI.Controllers
{

    public class ProfileController : Controller
    {
      [Authorize]
        public IActionResult MyProfile()
        {
            //var userName = User.Identity.Name;
            //ViewBag.UserName = userName;
            return View();
        }
    }
}
