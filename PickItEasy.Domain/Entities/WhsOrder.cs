using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public abstract class WhsOrder : Document
    {
        public List<Product>? Products { get; set; }
        //public List<WhsOrderProduct>? WhsOrderProducts { get; set; }
    }
}
