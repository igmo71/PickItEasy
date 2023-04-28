using MediatR;

namespace PickItEasy.Application.MediatR.Services.Products.Queries.IsExistsById
{
    public class IsExistsByIdQuery : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
