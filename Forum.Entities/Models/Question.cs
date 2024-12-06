namespace Forum.Entities.Models
{
	public class Question:BaseEntity
	{
		public string Title { get; set; }

		public string Content { get; set; }

		public int CategoryId { get; set; }
		public int AppUserId { get; set; }


		public virtual Category Category { get; set; }
		public virtual AppUser AppUser { get; set; }
		public virtual List<Answer>? Answers { get; set; }

	}
}
