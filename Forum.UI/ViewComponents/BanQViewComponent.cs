using Forum.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.UI.ViewComponents
{
    public class BanQViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int appUserId)
        {

			var userRole = HttpContext.Session.GetString("UserRole")?.Trim('"');
			ViewBag.AppUserId = appUserId;
			return View("Default", userRole);



		}
    }
}
