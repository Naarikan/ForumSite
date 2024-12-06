using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Entities.Enums;
using Forum.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Forum.Entities.Models
{
	public class AppUser : IdentityUser<int>, IEntity
	{
		public AppUser()
		{
			CreatedDate = DateTime.Now;
			Status = DataStatus.Inserted;
		}

		public int ID { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public DataStatus Status { get; set; }


        
        public virtual List<Question>? Questions { get; set; }
        public virtual List<Answer>? Answers { get; set; }

    }
}
