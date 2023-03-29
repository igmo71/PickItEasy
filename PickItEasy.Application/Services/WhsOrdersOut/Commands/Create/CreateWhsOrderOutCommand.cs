using MediatR;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommand : IRequest<CreateWhsOrderOutVm>
    {
        public required CreateWhsOrderOutDto CreateWhsOrderOutDto { get; set; }
    }
}
