﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class DocumentItem : BaseEntity, IHasId, IHasName
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
