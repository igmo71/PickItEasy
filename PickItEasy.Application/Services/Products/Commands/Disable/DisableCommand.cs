﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Disable
{
    public class DisableCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
