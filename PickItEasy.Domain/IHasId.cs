﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain
{
    public interface IHasId
    {
        public Guid Id { get; set; }
    }
}
