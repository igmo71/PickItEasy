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
    public class WhsOrderHistoryConfiguration : IEntityTypeConfiguration<WhsOrderHistory>
    {
        public void Configure(EntityTypeBuilder<WhsOrderHistory> builder)
        {
        }
    }
}
