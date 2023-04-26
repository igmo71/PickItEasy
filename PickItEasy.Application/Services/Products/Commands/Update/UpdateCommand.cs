using MediatR;
using PickItEasy.Application.Models.Products;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required ProductDto ProductDto { get; set; }
    }
}
