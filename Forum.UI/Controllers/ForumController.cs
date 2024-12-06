using Forum.BLL.ManagerServices.Abstract;
using Forum.BLL.ManagerServices.Concrete;
using Forum.Entities.Models;
using Forum.UI.Authorize;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.UI.Controllers
{
    public class ForumController : Controller
    {
        IAppUserManager _userManager;
        IQuestionManager _questionManager;
        IAnswerManger _answerManager;

        public ForumController(IQuestionManager questionManager, IAnswerManger answerManager,IAppUserManager userManager)
        {
            _questionManager = questionManager;
            _answerManager = answerManager;
            _userManager = userManager;

        }


        public IActionResult Home()
        {
           var questions = _questionManager
                                        .GetActivesAsync()
                                        .Include(q => q.Category)  
                                        .Include(q => q.AppUser);   
            return View(questions);
        }

        public IActionResult Search(string searchTerm)
        {
            IQueryable<Question> questions = _questionManager
                                         .GetActivesAsync()
                                         .Include(q => q.Category)  
                                         .Include(q => q.AppUser);   
            if (searchTerm == null)
            {
                return RedirectToAction("Home");
            }
            else
            {
                var filterQuestions = questions.Where(q => q.Title.Contains(searchTerm) || q.Content.Contains(searchTerm));
                ViewData["searchTerm"] = searchTerm;
                return View(filterQuestions);
            }
        }



        public async Task<IActionResult> QuestionAnswers(int id)
        {
            var question = await _questionManager
        .GetAllAsync()  
        .Include(q => q.AppUser)  
        .FirstOrDefaultAsync(q => q.ID == id);


            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [RoleAuthorize("SAdmin", "NAdmin", "User")]
        [HttpGet]
        public IActionResult Reply(int id)
        {
           
            ViewBag.QuestionId = id;  
            return View();
        }

        [RoleAuthorize("SAdmin", "NAdmin", "User")]
        [HttpPost]
        public async Task<IActionResult> Reply(Answer _answer, int id)
        {
            var username = HttpContext.Session.GetString("UserName")?.Trim('"');
            if (string.IsNullOrEmpty(username))
            {
               
                return RedirectToAction("Login", "Login");
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
               
                return NotFound("Kullanıcı bulunamadı.");
            }

            if (user.Status != Entities.Enums.DataStatus.Deleted)
            {
                Answer answer = new Answer()
                {
                    AppUserId = user.Id,
                    Content = _answer.Content,
                    QuestionId = id
                };


                await _answerManager.AddAsync(answer);


                return RedirectToAction("QuestionAnswers", "Forum", new { id = id });
            }
            else
            {
                return NotFound("Banlandınız,Sorulara Cevap veremezsiniz");
            }
        }

    }
}
