using Microsoft.AspNetCore.Mvc;

namespace Forum.UI.ViewComponents
{
    public class RoleViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userRole =HttpContext.Session.GetString("UserRole")?.Trim('"');
            return View("Default", userRole);
        }

    }
}
