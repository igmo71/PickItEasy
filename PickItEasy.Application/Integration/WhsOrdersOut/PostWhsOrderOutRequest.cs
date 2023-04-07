using MediatR;
using PickItEasy.Application.Dtos;
using System.Net;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class PostWhsOrderOutRequest : IRequest<string>
    {
        public required WhsOrderOutVm WhsOrderOutVm { get; set; }
    }
}
