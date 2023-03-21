using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class WhsOrderOutProductConfiguration : IEntityTypeConfiguration<WhsOrderOutProduct>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutProduct> builder)
        {
            builder.HasKey(wop => wop.Id);
            builder.HasOne(wop => wop.WhsOrder).WithMany(o => o.Products)
                .HasForeignKey(wop => wop.WhsOrderId).HasPrincipalKey(o => o.Id);
            builder.HasOne(wop => wop.Product).WithMany()
                .HasForeignKey(wop => wop.ProductId).HasPrincipalKey(p => p.Id);
        }
    }
}
