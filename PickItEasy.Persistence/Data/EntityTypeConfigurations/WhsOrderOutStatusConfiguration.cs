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
            foreach (var item in Integration.Connectors.Ut1c.SeedData.WhsOrderOutStatusInitial.List)
            {
                builder.HasData(new WhsOrderOutStatus
                {
                    Id = item.Id,
                    Value = item.Value,
                    IsActive = item.IsActive,
                    Name = item.Name,
                    Synonym = item.Synonym
                });
            }
        }
    }
}
