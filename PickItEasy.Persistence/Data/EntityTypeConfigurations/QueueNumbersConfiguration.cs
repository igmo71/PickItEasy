using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class QueueNumbersConfiguration : IEntityTypeConfiguration<QueueNumber>
    {
        public void Configure(EntityTypeBuilder<QueueNumber> builder)
        {
            builder.HasKey(e => e.Value);
            SeedQueueNumbers(builder);
        }

        private void SeedQueueNumbers(EntityTypeBuilder<QueueNumber> builder)
        {
            foreach (var item in QueueNumber.Generate())
            {
                builder.HasData(item);
            }

        }
    }
}
