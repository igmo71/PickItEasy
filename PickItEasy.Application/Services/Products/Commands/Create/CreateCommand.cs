﻿using MediatR;
using PickItEasy.Application.Models.Products;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateCommand : IRequest<ProductDto>
    {
        public required ProductDto ProductDto { get; init; }
    }
}
