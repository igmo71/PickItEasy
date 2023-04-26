using MediatR;
using PickItEasy.Application.Models.Warehouse;

namespace PickItEasy.Application.Services.Warehouses.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public required WarehouseDto WarehouseDto { get; set; }
    }
}
