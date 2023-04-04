using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.Contains
{
    public class ContainsValueQuery: IRequest<bool>
    {
        public int Value { get; set; }
    }
}
