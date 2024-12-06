using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.BLL.ManagerServices.Abstract;
using Forum.BLL.ManagerServices.Concrete;
using Forum.Dal.Repositories.Abstract;
using Forum.Dal.Repositories.Concrete;

using Microsoft.Extensions.DependencyInjection;

namespace Forum.BLL.DependencyResolvers
{
	public static class RepositoryManagerServiceInjection
	{
		public static IServiceCollection AddRepositoryManagerService(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));
			services.AddScoped(typeof(IManager<>),typeof(BaseManager<>));
			services.AddScoped<IAppUserRepository,AppUserRepository>();
			services.AddScoped<IAppUserManager,AppUserManager>();
			
			services.AddScoped<ICategoryRepository,CategoryRepository>();
			services.AddScoped<ICategoryManager,CategoryManager>();
			services.AddScoped<IQuestionRepository,QuestionRepository>();
			services.AddScoped<IQuestionManager,QuestionManager>();
			services.AddScoped<IAnswerRepository,AnswerRepository>();
			services.AddScoped<IAnswerManger,AnswerManager>();

			
			return services;
		}
	}
}
