using MediatR;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
