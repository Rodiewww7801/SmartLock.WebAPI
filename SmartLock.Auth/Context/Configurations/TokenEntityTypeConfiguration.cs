using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace SmartLock.Auth.Context.Configurations
{
	internal class TokenEntityTypeConfiguration: IEntityTypeConfiguration<Token>
	{
		public void Configure(EntityTypeBuilder<Token> builder)
		{
			builder.HasKey(p => p.Value);
			builder
				.Property(p => p.Value)
				.HasConversion(
					v => new Guid(v),
					v => v.ToString()
				);
		}
	}
}*/
