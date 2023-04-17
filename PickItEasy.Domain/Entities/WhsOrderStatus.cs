﻿using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public abstract class WhsOrderStatus : IHasName, IHasIsActive
    {
        public required Guid Id { get; set; }
        public required int Value { get; set; }
        public required string Name { get; set; }
        public required string Synonym { get; set; }
        public required bool Active { get; set; }
    }
}
