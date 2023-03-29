using MediatR;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required UpdateProductDto UpdateProductDto { get; set; }
    }
}
