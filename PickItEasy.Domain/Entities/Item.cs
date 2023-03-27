using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public abstract class Item : BaseEntity, IHasId, IHasName
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }

        //public List<Document>? Documents { get; set; }
        //public List<DocumentItem>? ItemDocuments { get; set; }
    }
}
