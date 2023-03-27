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
    public class WhsOrderConfiguration : IEntityTypeConfiguration<WhsOrder>
    {
        public void Configure(EntityTypeBuilder<WhsOrder> builder)
        {
            //builder.HasKey(o => o.Id);

            //builder.Property(o => o.DateTime).IsRequired();

            //builder.Property(o => o.Number).IsRequired()
            //    .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.NUMBER_MAX_LENGTH);

            //builder.Property(o => o.Name).IsRequired()
            //    .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.NAME_MAX_LENGTH);            
        }
    }
}
