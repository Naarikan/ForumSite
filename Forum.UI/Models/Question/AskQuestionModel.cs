using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forum.UI.Models.Question
{
    public class AskQuestionModel
    {
       
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AskQuestionModel Question { get; set; }

    }
}
