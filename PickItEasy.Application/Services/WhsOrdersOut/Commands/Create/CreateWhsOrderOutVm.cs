using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutVm
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }

        public List<CreateWhsOrderOutProductVm>? Products { get; set; }
    }

    public class CreateWhsOrderOutProductVm
    {
        public Guid ProductId { get; set; }
        public float Count { get; set; }
    }
}
