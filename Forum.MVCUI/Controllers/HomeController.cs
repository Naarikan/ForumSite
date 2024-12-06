using Microsoft.AspNetCore.Mvc;

namespace Forum.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
