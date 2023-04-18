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
            builder.HasData(
                new QueueNumber
                {
                    CharValue = 0,
                    NumValue = 0,
                    Value = "A000"
                });
        }
    }
}
