using MediatR;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class PostWhsOrderOutRequest : IRequest<HttpStatusCode>
    {
        public required GetByIdWhsOrderOutVm GetByIdWhsOrderOutVm { get; set; }
    }
}
