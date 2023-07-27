using DomainSmartLockAggregate = SmartLock.Domain.Models.SmartLockAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Context.Configurations
{
    internal class SmartLockEntityTypeConfiguration : IEntityTypeConfiguration<DomainSmartLockAggregate.SmartLock>
    {
        public void Configure(EntityTypeBuilder<DomainSmartLockAggregate.SmartLock> builder)
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
                .HasMany(e => e.SmartLockAccesses)
                .WithOne()
                .HasForeignKey(fk => fk.SmartLockId);
        }
    }
}
