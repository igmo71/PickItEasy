using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class OrderProduct
    {
        public Order? Order { get; set; }
        public Guid OrderId { get; set; }

        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
