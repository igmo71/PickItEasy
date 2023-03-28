using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Dto
{
    public class WhsOrderOutVm
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }

        public List<WhsOrderOutProductVm>? Products { get; set; }
    }

    public class WhsOrderOutProductVm
    {
        public Guid Id { get; set; }
        public float Count { get; set; }
    }
}
