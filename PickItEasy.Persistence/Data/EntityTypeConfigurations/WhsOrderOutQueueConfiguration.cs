using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain.Entities;
using PickItEasy.Application.Common;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class WhsOrderOutQueueConfiguration : IEntityTypeConfiguration<WhsOrderOutQueue>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WhsOrderOutQueue> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);
            
            builder.Property(e => e.NameRu).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);
            
            builder.Property(e => e.Rank).IsRequired();
        }
    }
}
