using Microsoft.EntityFrameworkCore;
using SmartLock.EntityFramework;

namespace SmartLock.API.Configuration
{
	public static class ConfigServiceCollectionExtensions
	{

		public static IServiceCollection AddConfiguration(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContext<SmartLockDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("EFDefaultConnection")));
			return service;
		}
		public static IServiceCollection AddDependencyGroup(this IServiceCollection service) 
		{
			
			return service;
		}
	}
}
