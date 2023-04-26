using MediatR;
using PickItEasy.Application.Models.Warehouse;

namespace PickItEasy.Application.Services.Warehouses.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required WarehouseDto WarehouseDto { get; set; }
    }
}
