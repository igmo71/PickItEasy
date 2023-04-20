using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, WhsOrderOutListVm>
    {
        private readonly IMediator _mediator;

        public GetListQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<WhsOrderOutListVm> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var orderDictionaryVm = await _mediator.Send(new WhsOrdersOut.Queries.GetDictionaryByQueue.GetDictionaryByQueueQuery
            {
                SearchParameters = request.SearchParameters
            });

            var countByStatus = await _mediator.Send(new WhsOrdersOut.Queries.GetCountByStatus.GetCountByStatusQuery
            {
                SearchParameters = request.SearchParameters
            });

            var response = new WhsOrderOutListVm { Orders = orderDictionaryVm.Orders, CountByStatus = countByStatus };

            return response;
        }
    }
}
