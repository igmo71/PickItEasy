using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<GetByIdProductVm>
    {
        public Guid Id { get; set; }
    }
}
