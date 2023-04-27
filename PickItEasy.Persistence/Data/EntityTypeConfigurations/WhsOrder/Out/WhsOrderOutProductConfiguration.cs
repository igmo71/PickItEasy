using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder.Out
{
    public class WhsOrderOutProductConfiguration : IEntityTypeConfiguration<WhsOrderOutProduct>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutProduct> builder)
        {
            builder.HasKey(op => op.Id);

            builder.HasOne(op => op.WhsOrderOut).WithMany(o => o.WhsOrderOutProducts)
                .HasForeignKey(op => op.WhsOrderOutId).HasPrincipalKey(o => o.Id);

            builder.HasOne(op => op.Product).WithMany()
                .HasForeignKey(op => op.ProductId).HasPrincipalKey(p => p.Id);
        }
    }
}
