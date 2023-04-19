using MediatR;

namespace PickItEasy.Application.Services.Warehouses.Queries.IsExistsById
{
    public class IsExistsByIdQuery : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
