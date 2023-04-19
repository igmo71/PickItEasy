using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class BaseDocumentConfiguration : IEntityTypeConfiguration<BaseDocument>
    {
        public void Configure(EntityTypeBuilder<BaseDocument> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).IsRequired()
                .HasColumnType(EntityConfig.TYPE_VARCHAR).HasMaxLength(EntityConfig.MAX_LENGTH_NAME);
        }
    }
}
