using Microsoft.AspNetCore.Mvc;
using Forum.UI.Authorize;
using Forum.UI.ExtensionClasses;
using Forum.BLL.ManagerServices.Abstract;
using Forum.BLL.ManagerServices.Concrete;

namespace Forum.UI.Controllers
{
    [RoleAuthorize("SAdmin", "NAdmin", "User")]
    public class ProfileController : Controller
    {
        IAppUserManager _appUserManager;
        IQuestionManager _questionManager;
        IAnswerManger _answerManager;
        public ProfileController(IAppUserManager appUserManager,IAnswerManger answerManager,IQuestionManager questionManager)
        {
            _appUserManager = appUserManager;
            _questionManager = questionManager;
            _answerManager = answerManager;
        }

        public async Task<IActionResult> MyProfile()
        {
            var username = HttpContext.Session.GetString("UserName")?.Trim('"');
            var user = await _appUserManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }

            // Kullanıcı ile ilişkili soruları ve cevapları yükle
            var questions = await _questionManager.GetFilterAsync(q => q.AppUserId == user.Id);
            var answers = await _answerManager.GetFilterAsync(a => a.AppUserId == user.Id);

            user.Questions = questions;
            user.Answers = answers;

            return View(user);
        }
    }
}
