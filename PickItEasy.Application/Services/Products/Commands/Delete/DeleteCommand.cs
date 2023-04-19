using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.Products.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public required ProductDto ProductDto { get; set; }
    }
}
