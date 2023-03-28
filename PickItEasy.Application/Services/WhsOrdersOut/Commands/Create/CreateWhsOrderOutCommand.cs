using MediatR;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Application.Services.WhsOrdersOut.Dto;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersExpense.Commands.CreateWhsOrderExpense
{
    public class CreateWhsOrderOutCommand : IRequest<WhsOrderOutVm>
    {
        public CreateWhsOrderOutDto? CreateWhsOrderOutDto { get; set; }
    }
}
