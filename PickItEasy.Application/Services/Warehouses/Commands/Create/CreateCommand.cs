﻿using MediatR;
using PickItEasy.Application.Models.Warehouses;

namespace PickItEasy.Application.Services.Warehouses.Commands.Create
{
    public class CreateCommand : IRequest<WarehouseDto>
    {
        public required WarehouseDto WarehouseDto { get; set; }
    }
}
