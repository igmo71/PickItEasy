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
    public class WhsOrderOutConfiguration : IEntityTypeConfiguration<WhsOrderOut>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOut> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(wo => wo.DateTime).IsRequired();

            builder.Property(o => o.Number).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.NUMBER_MAX_LENGTH);

            builder.Property(o => o.Name).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.NAME_MAX_LENGTH);

            builder.HasMany(o => o.Products).WithMany()
                .UsingEntity<WhsOrderOutProduct>(
                    b => b.HasOne(op => op.Product).WithMany().HasForeignKey(op => op.ProductId),
                    b => b.HasOne(op => op.WhsOrderOut).WithMany(o => o.WhsOrderOutProducts).HasForeignKey(op => op.WhsOrderOutId),
                    b =>
                    {
                        b.HasKey(op => op.Id);
                    });
        }
    }
}
