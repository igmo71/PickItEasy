using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Dtos
{
    public class WarehouseDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool Active { get; set; }
    }
}
