using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.Warehouses.Queries.GetById
{
    public class GetByIdQuery : IRequest<WarehouseVm>
    {
        public required Guid Id { get; set; }
    }
}
