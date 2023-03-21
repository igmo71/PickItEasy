using MediatR;
using PickItEasy.Application.Services.Products.Vm;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<ProductVm>
    {
        public CreateProductDto? CreateProductDto { get; set; }
    }
}
