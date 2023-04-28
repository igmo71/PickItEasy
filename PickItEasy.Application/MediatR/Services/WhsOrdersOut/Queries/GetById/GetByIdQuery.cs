using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdQuery : IRequest<WhsOrderOutVm>
    {
        public Guid Id { get; set; }
    }
}
