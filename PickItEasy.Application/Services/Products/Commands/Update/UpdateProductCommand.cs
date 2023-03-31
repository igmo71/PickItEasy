﻿using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required ProductDto ProductDto { get; set; }
    }
}
