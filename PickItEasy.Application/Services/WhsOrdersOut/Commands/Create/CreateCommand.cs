using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateCommand : IRequest<WhsOrderOutDto>
    {
        public required WhsOrderOutDto WhsOrderOutDto { get; set; }
    }
}
