using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public abstract class DocumentQueue : IHasId, IHasName
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
