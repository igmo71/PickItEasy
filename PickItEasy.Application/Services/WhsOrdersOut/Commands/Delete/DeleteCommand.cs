using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
