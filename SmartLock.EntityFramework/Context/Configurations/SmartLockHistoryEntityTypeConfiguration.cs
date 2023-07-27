using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLock.Domain.Models.HistoryAggreagate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Context.Configurations
{
    internal class SmartLockHistoryEntityTypeConfiguration : IEntityTypeConfiguration<SmartLockConsumerHistory>
    {
        public void Configure(EntityTypeBuilder<SmartLockConsumerHistory> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasConversion(
                    id => new Guid(id),
                    id => id.ToString()
                );
        }
    }
}
