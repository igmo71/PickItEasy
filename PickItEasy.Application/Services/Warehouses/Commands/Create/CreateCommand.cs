using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Warehouses.Commands.Create
{
    public class CreateCommand : IRequest<WarehouseDto>
    {
        public required WarehouseDto WarehouseDto { get; set; }
    }
}
