using Forum.BLL.ManagerServices.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.UI.Controllers
{
    public class AnswerController : Controller
    {
        IAnswerManger _answerManger;
        IAppUserManager _appUserManager;

        public AnswerController(IAnswerManger answerManger, IAppUserManager appUserManager)
        {
            _answerManger = answerManger;
            _appUserManager = appUserManager;

        }

        public async Task<IActionResult> MyAnswers()
        {

            var username = HttpContext.Session.GetString("UserName")?.Trim('"');
            var user = await _appUserManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var myAnswers =await _answerManger.GetFilterAsync(x=>x.AppUserId==user.Id);

            return View(myAnswers);
        }
    }
}
