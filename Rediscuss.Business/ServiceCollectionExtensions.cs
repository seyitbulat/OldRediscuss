using Microsoft.Extensions.DependencyInjection;

namespace Rediscuss.Business
{
	public static class ServiceCollectionExtensions
	{
		public static void AddBusinessServices(this IServiceCollection service)
		{
			service.AddAutoMapper(typeof(Rediscuss.Business.Profiles.AutoMapperProfile));
		}
	}
}
