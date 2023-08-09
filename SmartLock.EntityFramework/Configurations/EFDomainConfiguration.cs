using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLock.Domain.DataManager;
using SmartLock.Domain.Repositories;
using SmartLock.EntityFramework.Constants;
using SmartLock.EntityFramework.Context;
using SmartLock.EntityFramework.DataManager._Impl;
using SmartLock.EntityFramework.Repositories._Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Configurations
{
    public static class EFDomainConfiguration
	{
		public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<SmartLockDBContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString(SmartLockEFDefaults.EFDefaultConnectionPath))
			);

		}
		public static void RegisterDependecies(IServiceCollection services)
		{
			services.AddScoped<IDataBaseManager, DataBaseManager>();
			services.AddScoped<IConsumerFaceRepository, ConsumerFaceRepository>();
			services.AddScoped<IConsumerRepository, ConsumerRespository>();
			services.AddScoped<IHistoryRepository, HistoryRepository>();
			services.AddScoped<ISmartLockRepository, SmartLockRepository>();
		}
	}
}
