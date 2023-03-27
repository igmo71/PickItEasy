using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOutProduct : WhsOrderProduct
    {
        public Guid WhsOrderOutId { get; set; }
        public WhsOrderOut? WhsOrderOut { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
