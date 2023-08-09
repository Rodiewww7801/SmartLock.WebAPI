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
	public class UserEntityTypeConfigurationL: IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(p => p.Id);
			builder
				.Property(p => p.Id)
				.HasConversion(
					v => new Guid(v),
					v => v.ToString()
				);

			builder
				.Property(p => p.Role)
				.HasConversion(
					v => v.ToString(),
					v => Enum.Parse<User.RoleEnum>(v)
				);

			builder
				.HasMany(p => p.RefreshSessions)
				.WithOne();
		}
	}
}
