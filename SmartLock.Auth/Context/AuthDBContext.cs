using Microsoft.EntityFrameworkCore;
using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Context
{
	internal class AuthDBContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<RefreshSession> RefreshSessions { get; set; }

		public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
