using SmartLock.API.Handlers;
using SmartLock.API.Handlers._Impl;
using SmartLock.Auth.Configurations;
using SmartLock.Domain.Configurations;
using SmartLock.EntityFramework.Configurations;
using System.Text;


namespace SmartLock.API.Configuration
{
    public static class ConfigServiceCollectionExtensions
	{

		public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddControllers();
			service.AddHttpContextAccessor();
			AuthConfigurations.ConfigureServices(service, configuration);
			EFDomainConfiguration.ConfigureServices(service, configuration);
			return service;
		}
		public static IServiceCollection AddDependencyGroup(this IServiceCollection service) 
		{
			DomainConfigurations.RegisterDependecies(service);
			EFDomainConfiguration.RegisterDependecies(service);
			AuthConfigurations.RegisterDependecies(service);

			service.AddScoped<IConsumerEventHandler, ConsumerEventHandler>();

			return service;
		}
	}
}
