using MediatR;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<GetByIdProductVm>
    {
        public Guid Id { get; set; }
    }
}
