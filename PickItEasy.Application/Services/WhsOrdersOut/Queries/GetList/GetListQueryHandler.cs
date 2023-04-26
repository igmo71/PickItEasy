using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

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
            var getDictionaryByQueueQuery = new WhsOrdersOut.Queries.GetDictionaryByQueue.GetDictionaryByQueueQuery
            {
                SearchParameters = request.SearchParameters
            };

            var orderDictionaryVm = await _mediator.Send(getDictionaryByQueueQuery, cancellationToken);


            var getCountByStatusQuery = new WhsOrdersOut.Queries.GetCountByStatus.GetCountByStatusQuery
            {
                SearchParameters = request.SearchParameters
            };

            var countByStatus = await _mediator.Send(getCountByStatusQuery, cancellationToken);

            var response = new WhsOrderOutListVm { Orders = orderDictionaryVm.Orders, CountByStatus = countByStatus };

            return response;
        }
    }
}
