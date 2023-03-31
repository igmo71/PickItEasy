using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutQuery : IRequest<WhsOrderOutVm>
    {
        public Guid Id { get; set; }
    }
}
