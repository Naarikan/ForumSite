using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Forum.Dal.Configurations
{
	public class AnswerConfiguration:BaseConfiguration<Answer>
	{
		public override void Configure(EntityTypeBuilder<Answer> builder)
		{
			base.Configure(builder);

			// Question ile ilişki
			builder.HasOne(a => a.Question)
				.WithMany(q => q.Answers)
				.HasForeignKey(a => a.QuestionId)
				.OnDelete(DeleteBehavior.Restrict);

			
		}
	}
}
