﻿using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class PostWhsOrderOutRequest : IRequest<string>
    {
        public required WhsOrderOutVm WhsOrderOutVm { get; set; }
    }
}
