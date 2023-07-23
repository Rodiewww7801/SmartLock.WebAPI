using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLock.Domain.Models.ConsumerFaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Configurations
{
    internal class ConsumerFaceEntityTypeConfiguration : IEntityTypeConfiguration<ConsumerFace>
    {
        public void Configure(EntityTypeBuilder<ConsumerFace> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasConversion(
                    v => new Guid(v),
                    v => v.ToString()
                );

            builder
                .Property(p => p.TypeOfUsing)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<ConsumerFace.TypeOfUsingEnum>(v)
                );
        }
    }
}
