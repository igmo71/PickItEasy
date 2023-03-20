using MediatR;
using PickItEasy.Application.Services.WhsOrdersOut.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class GetWhsOrderOutQuery : IRequest<WhsOrderOutDto>
    {
        public Guid Id { get; set; }
    }
}
