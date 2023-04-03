using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class WhsOrderOutStatusConfiguration : IEntityTypeConfiguration<WhsOrderOutStatus>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutStatus> builder)
        {
            SeedWhsOrderOutStatus(builder);
        }

        private static void SeedWhsOrderOutStatus(EntityTypeBuilder<WhsOrderOutStatus> builder)
        {
            foreach (var status in Integration.Connectors.Ut1c.WhsOrderOutStatus.List)
            {
                builder.HasData(new WhsOrderOutStatus
                {
                    Id = status.Id,
                    Value = status.Value,
                    Name = status.Name,
                    Synonym = status.Synonym
                });
            }
        }
    }
}
