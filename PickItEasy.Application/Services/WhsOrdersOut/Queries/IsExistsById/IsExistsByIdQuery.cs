using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.IsExistsById
{
    public class IsExistsByIdQuery : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
