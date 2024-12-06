namespace Forum.Entities.Models
{
	public class Category:BaseEntity
	{
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }

		public virtual List<Question> Questions { get; set; }
	}
}
