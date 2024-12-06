using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.MVCUI.Controllers
{
    
    public class QuestionController : Controller
    {
        
        [HttpGet]
        public IActionResult AskQuestion()
        {

            return View();
        }
    }
}
