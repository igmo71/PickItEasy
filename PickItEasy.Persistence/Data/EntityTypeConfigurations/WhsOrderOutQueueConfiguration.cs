﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain.Entities;
using PickItEasy.Integration.Connectors.Ut1c.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence.Data.EntityTypeConfigurations
{
    public class WhsOrderOutQueueConfiguration : IEntityTypeConfiguration<WhsOrderOutQueue>
    {
        public void Configure(EntityTypeBuilder<WhsOrderOutQueue> builder)
        {
            SeedWhsOrderOutQueue(builder);
        }

        private void SeedWhsOrderOutQueue(EntityTypeBuilder<WhsOrderOutQueue> builder)
        {
            foreach (var item in WhsOrderOutQueueInitial.List)
                builder.HasData(new WhsOrderOutQueue
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
