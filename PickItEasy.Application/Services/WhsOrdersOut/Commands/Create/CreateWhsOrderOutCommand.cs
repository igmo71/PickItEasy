using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommand : IRequest<CreateWhsOrderOutVm>
    {
        public required CreateWhsOrderOutDto CreateWhsOrderOutDto { get; set; }
    }
}
