using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdQuery : IRequest<WhsOrderOutVm>
    {
        public Guid Id { get; set; }
    }
}
