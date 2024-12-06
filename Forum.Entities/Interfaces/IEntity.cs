using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Entities.Enums;

namespace Forum.Entities.Interfaces
{
	public interface IEntity
	{
		public int ID { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public DataStatus Status { get; set; }	
	}
}
