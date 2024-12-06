using Forum.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Dal.Configurations
{
	public class AppUserConfiguration:BaseConfiguration<AppUser>
	{
		public override void Configure(EntityTypeBuilder<AppUser> builder)
		{
			base.Configure(builder);
			builder.Ignore(x => x.ID);
			
		}
	}
}
