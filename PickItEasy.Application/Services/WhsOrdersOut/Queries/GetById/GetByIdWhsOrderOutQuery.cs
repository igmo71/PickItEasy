using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutQuery : IRequest<GetByIdWhsOrderOutVm>
    {
        public Guid Id { get; set; }
    }
}
