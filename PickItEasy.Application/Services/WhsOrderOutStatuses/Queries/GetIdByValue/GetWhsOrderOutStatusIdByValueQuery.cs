using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetIdByValue
{
    public class GetWhsOrderOutStatusIdByValueQuery : IRequest<Guid>
    {
        public int Value { get; set; }
    }
}
