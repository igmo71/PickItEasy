using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutQuery : IRequest<GetByIdWhsOrderOutVm>
    {
        public Guid Id { get; set; }
    }
}
