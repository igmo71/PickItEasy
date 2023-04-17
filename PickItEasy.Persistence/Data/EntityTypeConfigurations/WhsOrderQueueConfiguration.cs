using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain.Entities;
using PickItEasy.Application.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class WhsOrderQueueConfiguration : IEntityTypeConfiguration<WhsOrderQueue>
    {
        public void Configure(EntityTypeBuilder<WhsOrderQueue> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Value).IsRequired();
            
            builder.Property(e => e.Active).IsRequired();
            
            builder.Property(e => e.Name).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);
            
            builder.Property(e => e.Synonym).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);
        }
    }
}
