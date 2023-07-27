using Microsoft.EntityFrameworkCore;
using SmartLock.API.Handlers;
using SmartLock.API.Handlers._Impl;
using SmartLock.Domain.Unity;
using SmartLock.EntityFramework.Context;
using SmartLock.EntityFramework.Unity;

namespace SmartLock.API.Configuration
{
    public static class ConfigServiceCollectionExtensions
	{

		public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddControllers();
			EFBootstrapper.ConfigureServices(service, configuration);
			return service;
		}
		public static IServiceCollection AddDependencyGroup(this IServiceCollection service) 
		{
			EFBootstrapper.RegisterDependecies(service);
			DomainBootstrapper.RegisterDependecies(service);
			service.AddScoped<IConsumerEventHandler, ConsumerEventHandler>();
			return service;
		}
	}
}
