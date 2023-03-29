using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class WhsOrderInProductConfiguration : IEntityTypeConfiguration<WhsOrderInProduct>
    {
        public void Configure(EntityTypeBuilder<WhsOrderInProduct> builder)
        {
            builder.HasKey(op => op.Id);

            builder.HasOne(op => op.WhsOrderIn).WithMany(o => o.WhsOrderInProducts)
                .HasForeignKey(op => op.WhsOrderInId).HasPrincipalKey(o => o.Id);

            builder.HasOne(op => op.Product).WithMany()
                .HasForeignKey(op => op.ProductId).HasPrincipalKey(p => p.Id);
        }
    }
}
