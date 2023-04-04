using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<ProductVm>
    {
        public required Guid Id { get; set; }
    }
}
