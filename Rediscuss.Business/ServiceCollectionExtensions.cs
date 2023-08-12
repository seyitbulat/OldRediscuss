using Microsoft.Extensions.DependencyInjection;
using NLog;
using Rediscuss.Business.Implementations;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.EF.Repositories;
using Rediscuss.DataAccsess.Interfaces;

namespace Rediscuss.Business
{
	public static class ServiceCollectionExtensions
	{
		public static void AddBusinessServices(this IServiceCollection service)
		{
			service.AddAutoMapper(typeof(Rediscuss.Business.Profiles.AutoMapperProfile));

			service.AddScoped<IUserRepository, UserRepository>();
			service.AddScoped<IUserBs, UserBs>();

			service.AddScoped<ISubredisRepository, SubredisRepository>();
			service.AddScoped<ISubredisBs, SubredisBs>();

			service.AddScoped<IPostRepository, PostRepository>();
			service.AddScoped<IPostBs, PostBs>();

			service.AddScoped<ILoggerBs, LoggerBs>();
			LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));
			service.ConfigureLoggerService();
		}

		public static void ConfigureLoggerService(this IServiceCollection service)
		{
			service.AddSingleton<ILoggerBs, LoggerBs>();
		}
	}
}
