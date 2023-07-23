﻿using SmartLock.Domain.Models.ConsumerAggregate;
using SmartLock.Domain.Models.SmartLockAggregate;
using SmartLockAggregate = SmartLock.Domain.Models.SmartLockAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLock.EntityFramework.Configurations;
using System.Reflection;
using SmartLock.Domain.Models.HistoryAggreagate;
using SmartLock.Domain.Models.ConsumerFaceAggregate;
using SmartLock.Domain.Models.ConsumerAggregate;

namespace SmartLock.EntityFramework.Context
{
    public class SmartLockDBContext : DbContext
    {
		public DbSet<Consumer> Consumers { get; set; }
		public DbSet<ConsumerFace> ConsumerFaces { get; set; }
		public DbSet<SmartLockAggregate.SmartLock> SmartLocks { get; set; }
		public DbSet<SmartLockConsumerHistory> SmartLockConsumerHistories { get; set; }
		public DbSet<SmartLockAccess> SmartLockAccesses { get; set; }
		public SmartLockDBContext(DbContextOptions<SmartLockDBContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
