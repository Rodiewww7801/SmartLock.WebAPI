using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLock.Domain.Repositories;
using SmartLock.Domain.Services.DataManager;
using SmartLock.EntityFramework.Context;
using SmartLock.EntityFramework.Repositories;
using SmartLock.EntityFramework.Services.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Unity
{
    public static class EFBootstrapper
	{
		public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<SmartLockDBContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("EFDefaultConnection"))
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
