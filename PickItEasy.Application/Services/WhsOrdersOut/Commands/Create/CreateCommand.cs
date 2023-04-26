using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateCommand : IRequest<WhsOrderOutDto>
    {
        public required WhsOrderOutDto WhsOrderOutDto { get; set; }
    }
}
