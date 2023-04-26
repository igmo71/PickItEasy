using MediatR;
using PickItEasy.Application.Models.Warehouses;

namespace PickItEasy.Application.Services.Warehouses.Queries.GetById
{
    public class GetByIdQuery : IRequest<WarehouseVm>
    {
        public required Guid Id { get; set; }
    }
}
