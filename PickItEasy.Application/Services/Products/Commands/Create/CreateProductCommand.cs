using MediatR;
using PickItEasy.Application.Services.Products.Queries.GetById;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreateProductVm>
    {
        public required CreateProductDto CreateProductDto { get; init; }
    }
}
