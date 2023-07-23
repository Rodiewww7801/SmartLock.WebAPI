using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLock.Domain.Models.SmartLockAggregate;

namespace SmartLock.EntityFramework.Configurations
{
    internal class SmartLockAccessEntityTypeConfiguration : IEntityTypeConfiguration<SmartLockAccess>
    {
        public void Configure(EntityTypeBuilder<SmartLockAccess> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasConversion(
                    id => new Guid(id),
                    id => id.ToString()
                );

            builder
                .Property(p => p.AccessState)
                .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<SmartLockAccess.AccessStateEnum>(v)
            );
        }
    }
}
