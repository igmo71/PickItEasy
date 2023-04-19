using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities;
using PickItEasy.Integration.Connectors.Ut1c.SeedData;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder.Out
{
    public class WhsOrderOutQueueConfiguration : IEntityTypeConfiguration<WhsOrderOutQueue>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutQueue> builder)
        {
            SeedWhsOrderOutQueue(builder);
        }

        private void SeedWhsOrderOutQueue(EntityTypeBuilder<WhsOrderOutQueue> builder)
        {
            foreach (var item in WhsOrderOutQueueInitial.List)
                builder.HasData(new WhsOrderOutQueue
                {
                    Id = item.Id,
                    Value = item.Value,
                    Active = item.Active,
                    Name = item.Name,
                    Synonym = item.Synonym
                });
        }
    }
}
