using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities.WhsOrder;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder
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
