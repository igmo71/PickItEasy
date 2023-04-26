using MediatR;
using PickItEasy.Application.Models.Products;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdQuery : IRequest<ProductVm>
    {
        public required Guid Id { get; set; }
    }
}
