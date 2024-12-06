using Forum.Entities.Enums;
using Forum.Entities.Interfaces;

namespace Forum.Entities.Models
{
	public abstract class BaseEntity : IEntity
	{
		public BaseEntity()
		{
			CreatedDate = DateTime.Now;
			Status=DataStatus.Inserted;
		}
		public int ID { get; set; }
		public  DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public DataStatus Status { get; set; }
	}
}
