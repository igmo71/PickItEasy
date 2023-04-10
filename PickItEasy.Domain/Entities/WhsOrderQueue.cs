using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class WhsOrderQueue : IHasId, IHasName
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Synonym { get; set; }
        public required int Value { get; set; }
        public required bool IsActive { get; set; }
    }
}
