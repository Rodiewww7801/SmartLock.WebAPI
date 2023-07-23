using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLock.Domain.Models.ConsumerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Configurations
{
    internal class ConsumerEntityTypeConfiguration : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(p => p.Id)
                .HasConversion(
                    v => new Guid(v),
                    v => v.ToString()
                );

            builder
                .Property(p => p.SecurityLevel)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<Consumer.SecurityLevelEnum>(v)
                );
        }
    }
}
