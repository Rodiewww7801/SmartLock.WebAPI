using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Context.Configurations
{
	internal class RefreshSessionEntityTypeConfiguration: IEntityTypeConfiguration<RefreshSession>
	{
		public void Configure(EntityTypeBuilder<RefreshSession> builder)
		{
			builder
				.HasKey(e => e.Id);

			builder
				.Property(e => e.Id)
				.HasConversion(
					v => new Guid(v),
					v => v.ToString()
				);

			builder
				.OwnsOne(
					p => p.RefreshToken,
					options =>
					{
						options.Property(p => p.Value).HasColumnName("Value");
						options.Property(p => p.Expires).HasColumnName("Expires");
						options.Property(p => p.Created).HasColumnName("Created");
					}
				);
		}
	}
}
