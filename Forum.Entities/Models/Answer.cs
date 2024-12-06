namespace Forum.Entities.Models
{
	public class Answer:BaseEntity
	{
		public string Content { get; set; }

		public int QuestionId { get; set; }
		
		public int AppUserId { get; set; }


		public virtual Question Question { get; set; }
		public virtual AppUser AppUser { get; set; }
	}
}
