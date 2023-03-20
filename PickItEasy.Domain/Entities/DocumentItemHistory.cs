using PickItEasy.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class DocumentItemHistory : BaseEntity, IHasId, IHasDateTime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentItemId { get; set; }
    }
}
