﻿using Azure.Core;
using Microsoft.AspNetCore.DataProtection;
using SmartLock.API.Configuration;
using SmartLock.API.Controllers;
using System.Security.Claims;

namespace SmartLock.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services
				.ConfigureServices(builder.Configuration)
				.AddDependencyGroup();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			};

			app.UseHttpsRedirection();
			//app.UseStaticFiles();
			//app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}