﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities.Interfaces
{
    public interface IHasDateTime
    {
        public DateTime DateTime { get; set; }
    }
}
