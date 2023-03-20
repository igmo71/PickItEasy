using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Dto
{
    public class WhsOrderOutDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }
    }
}
