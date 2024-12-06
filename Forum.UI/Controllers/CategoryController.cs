using Forum.BLL.ManagerServices.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Forum.UI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryManager _manager;

        public CategoryController(ICategoryManager manager)
        {
            _manager=manager;
        }

        public IActionResult Categories()
        {
            var categories = _manager.GetAll();
            return View(categories);
        }
    }
}
