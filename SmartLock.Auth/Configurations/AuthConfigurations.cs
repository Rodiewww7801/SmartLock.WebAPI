using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartLock.Auth.Constants;
using SmartLock.Auth.Context;
using SmartLock.Auth.DataManagers;
using SmartLock.Auth.DataManagers._Impl;
using SmartLock.Auth.Repositories;
using SmartLock.Auth.Repositories._Impl;
using SmartLock.Auth.Services;
using SmartLock.Auth.Services._Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Configurations
{
    public static class AuthConfigurations
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration) 
		{
			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				{
					var secret = configuration[SLAuthDefaults.SecretPath];
					if (secret == null)
						throw new InvalidOperationException();
					options.TokenValidationParameters = new TokenValidationParameters
					{
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true
					};
				});

			services.AddDbContext<AuthDBContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString(SLAuthDefaults.AuthDBConnectionPath))
			);
			return services;
		}

		public static void RegisterDependecies(IServiceCollection services)
		{
			services.AddScoped<IAuthDataManager, AuthDataManager>();
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAuthService, AuthService>();
		}
	}
}
