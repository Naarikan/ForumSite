using Forum.BLL.ManagerServices.Abstract;
using Forum.Entities.Models;
using Forum.UI.Models.Question;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forum.UI.Controllers
{

    
    public class QuestionController : Controller
    {
        IQuestionManager _questionManager;
        IAppUserManager _userManager;
        ICategoryManager _categoryManager;
        public QuestionController(IQuestionManager questionManager, IAppUserManager userManager,ICategoryManager categoryManager)
        {
            _questionManager = questionManager;
            _userManager = userManager;
            _categoryManager = categoryManager;
        }


        public async Task<IActionResult> MyQuestions()
        {
            var username = HttpContext.Session.GetString("UserName")?.Trim('"');
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var questions = await _questionManager.GetFilterAsync(q => q.AppUserId == user.Id);

            return View(questions);

            
        }

        [HttpGet]
        public IActionResult AskQuestion()
        {
            var categories = _categoryManager.GetAll();
            var model = new AskQuestionModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.CategoryName
                }).ToList()
            };

            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> AskQuestion(AskQuestionModel qModel)
        {

            var username = HttpContext.Session.GetString("UserName")?.Trim('"');

            
           

            var user = await _userManager.FindByNameAsync(username);

            

            if (user == null)
            {
                
                return NotFound("Kullanıcı bulunamadı.");
            }

            if (user.Status != Entities.Enums.DataStatus.Deleted)
            {
                
                Question question = new Question
                {
                    Title = qModel.Title,
                    Content = qModel.Content,
                    CategoryId = qModel.CategoryId,
                    AppUserId = user.Id,  

                };


               
                await _questionManager.AddAsync(question);
                return RedirectToAction("MyQuestions");
            }
            else
            {

                return NotFound("Banlandınız");

            }


          

        }
    }


}
