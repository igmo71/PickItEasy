using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class DocumentType : BaseEntity, IHasId, IHasName
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
