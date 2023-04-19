using MediatR;

namespace PickItEasy.Application.Services.Products.Commands.Disable
{
    public class DisableCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
