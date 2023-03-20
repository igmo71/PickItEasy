using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class DocumentHistory<TDocument> : BaseEntity, IHasId, IHasDateTime
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public TDocument? Document { get; set; }
        public Guid DocumentId { get; set; }
    }
}
