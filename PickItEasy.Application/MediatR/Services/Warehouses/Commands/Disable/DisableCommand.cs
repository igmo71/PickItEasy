using MediatR;

namespace PickItEasy.Application.MediatR.Services.Warehouses.Commands.Disable
{
    public class DisableCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
