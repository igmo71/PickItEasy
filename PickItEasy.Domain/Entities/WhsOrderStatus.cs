using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class WhsOrderStatus : IHasId, IHasName
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string NameRu { get; set; }
        public required int Rank { get; set; }
    }
}
