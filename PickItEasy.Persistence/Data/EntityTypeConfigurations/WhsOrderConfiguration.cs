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
    public class WhsOrderConfiguration : IEntityTypeConfiguration<WhsOrder>
    {
        public void Configure(EntityTypeBuilder<WhsOrder> builder)
        {
            builder.HasMany(o => o.Products).WithOne(p => p.WhsOrder)
                .HasForeignKey(p => p.WhsOrderId).HasPrincipalKey(o => o.Id);
        }
    }
}
