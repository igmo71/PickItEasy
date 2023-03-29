using MediatR;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreateProductVm>
    {
        public required CreateProductDto CreateProductDto { get; init; }
    }
}
