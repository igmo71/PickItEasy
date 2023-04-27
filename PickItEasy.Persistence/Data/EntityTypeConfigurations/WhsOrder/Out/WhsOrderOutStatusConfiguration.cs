using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities.WhsOrder.Out;
using PickItEasy.Integration.Connectors.Ut1c.SeedData;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder.Out
{
    public class WhsOrderOutStatusConfiguration : IEntityTypeConfiguration<WhsOrderOutStatus>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutStatus> builder)
        {
            SeedWhsOrderOutStatus(builder);
        }

        private static void SeedWhsOrderOutStatus(EntityTypeBuilder<WhsOrderOutStatus> builder)
        {
            foreach (var item in WhsOrderOutStatusInitial.List)
            {
                builder.HasData(new WhsOrderOutStatus
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
}
