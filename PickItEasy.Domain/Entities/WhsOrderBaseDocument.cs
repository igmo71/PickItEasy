using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain.Entities
{
    public class WhsOrderBaseDocument : DocumentItem
    {
        public Guid BaseDocumentId { get; set; }
        public BaseDocument? BaseDocument { get; set; }
    }
}
