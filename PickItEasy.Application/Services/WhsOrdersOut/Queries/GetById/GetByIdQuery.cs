using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdQuery : IRequest<WhsOrderOutVm>
    {
        public Guid Id { get; set; }
    }
}
