using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommand : IRequest<WhsOrderOutDto>
    {
        public required WhsOrderOutDto WhsOrderOutDto { get; set; }
    }
}
