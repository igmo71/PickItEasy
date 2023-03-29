using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.IsExistsById
{
    public class IsExistsByIdWhsOrderOutQuery : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
