using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.BLL.DependencyResolvers
{
	public static class DbContextServiceInjection
	{
		public static IServiceCollection AddDbContextService(this IServiceCollection services)
		{
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
			services.AddDbContextPool<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")));
			return services;
		}
		
	}
}
