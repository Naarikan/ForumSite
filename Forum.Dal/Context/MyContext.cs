using Forum.Dal.Configurations;
using Forum.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Dal.Context
{
	public class MyContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
	{
		public MyContext(DbContextOptions<MyContext> opt) : base(opt)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new AppUserConfiguration());
			//builder.ApplyConfiguration(new AppUserProfileConfiguration());
			builder.ApplyConfiguration(new AnswerConfiguration());
			
		}

		public DbSet<AppUser> AppUsers { get; set; }
	
		public DbSet<Category> Categories	{ get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet <Answer> Answers { get; set; }

	}



}
