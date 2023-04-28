using MediatR;
using PickItEasy.Application.Models.Warehouses;

namespace PickItEasy.Application.MediatR.Services.Warehouses.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public required WarehouseDto WarehouseDto { get; set; }
    }
}
