using MediatR;

namespace PickItEasy.Application.MediatR.Services.Products.Commands.Disable
{
    public class DisableCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
