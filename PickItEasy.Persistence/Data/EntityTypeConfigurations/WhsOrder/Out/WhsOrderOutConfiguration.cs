using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder.Out
{
    public class WhsOrderOutConfiguration : IEntityTypeConfiguration<WhsOrderOut>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOut> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(wo => wo.DateTime).IsRequired();

            builder.Property(o => o.Number).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NUMBER);

            builder.Property(o => o.Name).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);

            //builder.Property(o => o.DateTime).IsRequired()
            //    .HasColumnType(EntityConfig.TYPE_DATETIME);

            builder.HasMany(o => o.Products).WithMany()
                .UsingEntity<WhsOrderOutProduct>(
                    b => b.HasOne(op => op.Product).WithMany().HasForeignKey(op => op.ProductId),
                    b => b.HasOne(op => op.WhsOrderOut).WithMany(o => o.WhsOrderOutProducts).HasForeignKey(op => op.WhsOrderOutId),
                    b =>
                    {
                        b.HasKey(op => op.Id);
                    });

            builder.HasOne(o => o.Status).WithMany().HasForeignKey(o => o.StatusId).HasPrincipalKey(s => s.Id).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(o => o.Queue).WithMany().HasForeignKey(o => o.QueueId).HasPrincipalKey(q => q.Id).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(o => o.Warehouse).WithMany().HasForeignKey(o => o.WarehouseId).HasPrincipalKey(q => q.Id).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(o => o.BaseDocuments).WithMany()
                .UsingEntity<WhsOrderOutBaseDocumentConfiguration>(
                    b => b.HasOne(od => od.BaseDocument).WithMany().HasForeignKey(od => od.BaseDocumentId),
                    b => b.HasOne(od => od.WhsOrderOut).WithMany().HasForeignKey(od => od.WhsOrderOutId),
                    b =>
                    {
                        b.HasKey(od => od.Id);
                    });
        }
    }
}
