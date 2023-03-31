using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public required ProductDto ProductDto { get; init; }
    }
}
