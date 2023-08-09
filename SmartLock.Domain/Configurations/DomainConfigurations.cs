using Microsoft.Extensions.DependencyInjection;
using SmartLock.Domain.Commands;
using SmartLock.Domain.Commands._Impl;
using SmartLock.Domain.Factory;
using SmartLock.Domain.Factory._Impl;
using SmartLock.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Configurations
{
    public static class DomainConfigurations
	{
		public static void RegisterDependecies(IServiceCollection services) {
			services.AddScoped(provider =>
				new Lazy<IConsumerRepository>(provider.GetRequiredService<IConsumerRepository>)
			);
			services.AddScoped(provider =>
				new Lazy<ISmartLockRepository>(provider.GetRequiredService<ISmartLockRepository>)
			);

			services.AddScoped<IConsumerCommand, ConsumerCommand>();
			services.AddScoped<ISmartLockCommand, SmartLockService>();
			services.AddScoped<IDomainCommandFactory, DomainCommandFactory>();
			services.AddLayzeResolution();
		}

		public static IServiceCollection AddLayzeResolution(this IServiceCollection services) {
			return services.AddTransient(typeof(Lazy<>), typeof(LazilyResolved<>));
		}
	}

	public class LazilyResolved<T>: Lazy<T>
	{
		public LazilyResolved(IServiceProvider provider) : base(provider.GetRequiredService<T>) { } 
	}
}
