using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutDictionaryByQueueVm
    {
        public Dictionary<Guid, WhsOrderOutLookupVm[]>? Orders { get; set; }
    }
}
