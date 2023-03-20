using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class Order : Document
    {
        public ICollection<OrderProduct>? Items { get; set; }

        public OrderType? OrderType { get; set; }

        public Guid OrderTypeId { get; set; }
    }
}
