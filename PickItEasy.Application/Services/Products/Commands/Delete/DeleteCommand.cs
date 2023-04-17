using MediatR;
using PickItEasy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public required ProductDto ProductDto { get; set; }
    }
}
