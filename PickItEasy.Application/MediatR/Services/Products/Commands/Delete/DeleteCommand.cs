using MediatR;
using PickItEasy.Application.Models.Products;

namespace PickItEasy.Application.MediatR.Services.Products.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public required ProductDto ProductDto { get; set; }
    }
}
