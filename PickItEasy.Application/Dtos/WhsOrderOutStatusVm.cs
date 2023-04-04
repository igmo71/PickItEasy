using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutStatusVm
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string? Synonym { get; set; }
    }
}
