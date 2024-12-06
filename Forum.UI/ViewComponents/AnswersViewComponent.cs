using Forum.BLL.ManagerServices.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.UI.ViewComponents
{
    public class AnswersViewComponent:ViewComponent
    {
        IAnswerManger _answerManager;

        public AnswersViewComponent(IAnswerManger answerManager)
        {
            _answerManager = answerManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int questionId)
        {
            var answers = _answerManager
          .GetFilter(a => a.QuestionId == questionId)
          .Include(q => q.AppUser).ToList();

            return View(answers);
        }
    }
}
