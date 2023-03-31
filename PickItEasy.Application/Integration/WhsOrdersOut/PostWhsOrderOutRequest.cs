using MediatR;
using PickItEasy.Application.Dtos;
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
        public required WhsOrderOutVm WhsOrderOutVm { get; set; }
    }
}
