using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class PostWhsOrderOutDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }

        public required List<PostWhsOrderOutProductDto> Products { get; set; }
    }

    public class PostWhsOrderOutProductDto
    {
        public Guid ProductId { get; set; }
        public float Count { get; set; }
    }
}
