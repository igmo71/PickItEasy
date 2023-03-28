﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required UpdateProductDto UpdateProductDto { get; set; }
    }
}
