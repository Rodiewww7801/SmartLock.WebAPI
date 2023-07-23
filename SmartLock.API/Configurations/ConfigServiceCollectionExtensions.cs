using Microsoft.EntityFrameworkCore;
using SmartLock.EntityFramework.Context;

namespace SmartLock.API.Configuration
{
    public static class ConfigServiceCollectionExtensions
	{

		public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddControllers();
			service.AddDbContext<SmartLockDBContext>(options => 
				options.UseSqlServer(configuration.GetConnectionString("EFDefaultConnection"))
			);
			return service;
		}
		public static IServiceCollection AddDependencyGroup(this IServiceCollection service) 
		{
			
			return service;
		}
	}
}
