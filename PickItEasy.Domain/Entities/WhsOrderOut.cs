﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOut : WhsOrder
    {
        public List<WhsOrderOutProduct>? WhsOrderOutProducts { get; set; }
    }
}
