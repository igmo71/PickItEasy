using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteWhsOrderOutCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
