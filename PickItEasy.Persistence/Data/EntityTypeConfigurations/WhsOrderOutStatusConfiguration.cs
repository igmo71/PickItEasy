using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class WhsOrderOutStatusConfiguration : IEntityTypeConfiguration<WhsOrderOutStatus>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutStatus> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);
        }
    }
}
