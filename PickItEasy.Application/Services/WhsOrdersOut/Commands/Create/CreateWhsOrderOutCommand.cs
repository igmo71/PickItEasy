using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommand : IRequest<CreateWhsOrderOutVm>
    {
        public required WhsOrderOutDto WhsOrderOutDto { get; set; }
    }
}
