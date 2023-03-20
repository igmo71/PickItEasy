using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class DocumentItemHistory<TDocument, TDocumentItem> : BaseEntity, IHasId, IHasDateTime
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public TDocument? Document { get; set; }
        public Guid DocumentId { get; set; }

        public TDocumentItem? DocumentItem { get; set; }
        public Guid DocumentItemId { get; set; }
    }
}
