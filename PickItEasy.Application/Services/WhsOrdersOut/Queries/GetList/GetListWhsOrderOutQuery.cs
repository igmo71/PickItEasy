using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetListWhsOrderOutQuery : IRequest<GetListWhsOrderOutVm>
    {
        public required WhsOrderOutSearchParameters SearchParameters { get; set; } 
    }
}
