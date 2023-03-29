using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteWhsOrderOutCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
