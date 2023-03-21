using MediatR;
using PickItEasy.Application.Services.Products.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<ProductVm>
    {
        public Guid Id { get; set; }
    }
}
