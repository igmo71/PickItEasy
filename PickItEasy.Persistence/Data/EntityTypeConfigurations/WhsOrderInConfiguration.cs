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
    public class WhsOrderInConfiguration : IEntityTypeConfiguration<WhsOrderIn>
    {
        public void Configure(EntityTypeBuilder<WhsOrderIn> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.DateTime).IsRequired();

            builder.Property(o => o.Number).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NUMBER);

            builder.Property(o => o.Name).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);

            builder.HasMany(o => o.Products).WithMany()
                .UsingEntity<WhsOrderInProduct>(
                    b => b.HasOne(op => op.Product).WithMany().HasForeignKey(op => op.ProductId),
                    b => b.HasOne(op => op.WhsOrderIn).WithMany(o => o.WhsOrderInProducts).HasForeignKey(op => op.WhsOrderInId),
                    b =>
                    {
                        b.HasKey(op => op.Id);
                    });
        }
    }
}
