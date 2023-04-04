using MediatR;
using PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.Contains
{
    public class ContainsValueQueryHandler : IRequestHandler<ContainsValueQuery, bool>
    {
        private readonly IMediator _mediator;
        public ContainsValueQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(ContainsValueQuery request, CancellationToken cancellationToken)
        {
            var statusLit = await _mediator.Send(new GetListQuery(), cancellationToken);
            var result = request.Value >= statusLit.MinBy(s => s.Value)?.Value
                        && request.Value >= statusLit.MaxBy(s => s.Value)?.Value;
            return result;
        }
    }
}
