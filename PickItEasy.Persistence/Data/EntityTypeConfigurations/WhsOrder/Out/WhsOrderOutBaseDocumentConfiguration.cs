using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations.WhsOrder.Out
{
    public class WhsOrderOutBaseDocumentConfiguration : IEntityTypeConfiguration<WhsOrderOutBaseDocument>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutBaseDocument> builder)
        {
            builder.HasKey(ob => ob.Id);

            builder.HasOne(ob => ob.WhsOrderOut).WithMany(o => o.WhsOrderOutBaseDocuments)
                .HasForeignKey(ob => ob.WhsOrderOutId).HasPrincipalKey(o => o.Id);

            builder.HasOne(ob => ob.BaseDocument).WithMany()
                .HasForeignKey(ob => ob.BaseDocumentId).HasPrincipalKey(b => b.Id);
        }
    }
}
