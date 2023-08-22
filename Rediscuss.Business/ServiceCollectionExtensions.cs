using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Rediscuss.Business.Implementations;
using Rediscuss.Business.Interfaces;
using Rediscuss.Business.Validators;
using Rediscuss.Business.Validators.DtoValidators;
using Rediscuss.DataAccsess.EF.Repositories;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.User;

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

			service.AddScoped<IJoinRepository, JoinRepository>();
			service.AddScoped<IJoinBs, JoinBs>();

			service.AddScoped<IPostImageRepository, PostImageRepository>();
			service.AddScoped<IPostImageBs, PostImageBs>();

			service.AddScoped<ILoggerBs, LoggerBs>();
			LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));
			service.ConfigureLoggerService();

			

			// validator
			service.AddValidatorsFromAssemblyContaining<UserValidator>();

			service.AddScoped<IValidate<UserPostDto, UserValidator>, Validate<UserPostDto, UserValidator>>();
		}

		public static void ConfigureLoggerService(this IServiceCollection service)
		{
			service.AddSingleton<ILoggerBs, LoggerBs>();
		}
	}
}
