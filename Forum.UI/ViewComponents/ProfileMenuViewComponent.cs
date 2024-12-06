using Microsoft.AspNetCore.Mvc;

namespace Forum.UI.ViewComponents
{
    public class ProfileMenuViewComponent:ViewComponent
    {
         public async  Task<IViewComponentResult> InvokeAsync()
        {
            var userName = HttpContext.Session.GetString("UserName");
            return View("Default", userName);
        }
    }
}
