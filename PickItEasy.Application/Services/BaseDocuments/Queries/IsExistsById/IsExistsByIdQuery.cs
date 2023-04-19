using MediatR;

namespace PickItEasy.Application.Services.BaseDocuments.Queries.IsExistsById
{
    public class IsExistsByIdQuery : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
