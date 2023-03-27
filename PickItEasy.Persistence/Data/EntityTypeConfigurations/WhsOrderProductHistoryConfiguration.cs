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
    public class WhsOrderProductHistoryConfiguration : IEntityTypeConfiguration<ProductHistory>
    {
        public void Configure(EntityTypeBuilder<ProductHistory> builder)
        {
            //builder.HasOne(woph => woph.WhsOrder).WithMany()
            //    .HasForeignKey(woph => woph.ItemId).HasPrincipalKey(d => d.Id);
            //builder.HasOne(woph => woph.Product).WithMany()
            //    .HasForeignKey(woph => woph.DocumentItemId).HasPrincipalKey(i => i.Id);
        }
    }
}
