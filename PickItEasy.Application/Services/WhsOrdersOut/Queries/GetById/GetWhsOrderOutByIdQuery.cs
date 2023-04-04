using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetWhsOrderOutByIdQuery : IRequest<WhsOrderOutVm>
    {
        public Guid Id { get; set; }
    }
}
