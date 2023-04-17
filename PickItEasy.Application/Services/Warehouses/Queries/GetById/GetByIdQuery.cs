using MediatR;
using PickItEasy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Warehouses.Queries.GetById
{
    public class GetByIdQuery : IRequest<WarehouseVm>
    {
        public required Guid Id { get; set; }
    }
}
