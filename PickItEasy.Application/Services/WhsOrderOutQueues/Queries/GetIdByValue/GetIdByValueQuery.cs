using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetIdByValue
{
    public class GetIdByValueQuery : IRequest<Guid>
    {
        public int Value { get; set; }
    }
}
