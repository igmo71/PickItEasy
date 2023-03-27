﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class Document : BaseEntity, IHasId, IHasDateTime, IHasNumber, IHasName
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public required string Number { get; set; }
        public required string Name { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}
