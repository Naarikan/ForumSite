using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Dal.Context;
using Forum.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.BLL.DependencyResolvers
{
	public static class IdentityExtensionService
	{
		public static IServiceCollection AddIdentityService(this IServiceCollection services)
		{
			services.AddIdentity<AppUser, IdentityRole<int>>(options =>
			{
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = false;
			}).AddEntityFrameworkStores<MyContext>()
			  .AddDefaultTokenProviders();

			return services;
		}
	}
}
