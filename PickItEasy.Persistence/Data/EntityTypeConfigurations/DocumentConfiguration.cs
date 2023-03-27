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
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(d => d.Id);
            
            builder.Property(d => d.DateTime)
                .IsRequired();
            
            builder.Property(d => d.Number)
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.NUMBER_MAX_LENGTH).IsRequired();
            
            builder.Property(d => d.Name)
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.NAME_MAX_LENGTH).IsRequired();
        }        
    }
}
