using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetDictionaryByQueue
{
    public class GetDictionaryByQueueQueryHandler : IRequestHandler<GetDictionaryByQueueQuery, WhsOrderOutDictionaryByQueueVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDictionaryByQueueQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutDictionaryByQueueVm> Handle(GetDictionaryByQueueQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.WhsOrdersOut
                .AsNoTracking()
                .Where(e => e.Active)
                .SearchByBarcode(request.SearchParameters)
                .SearchByTerm(request.SearchParameters)
                .SearchByStatus(request.SearchParameters)
                .OrderBy(e => e.StatusId)
                    .ThenBy(e => e.QueueId)
                    .ThenByDescending(e => e.ShipDateTime)
                .ProjectTo<WhsOrderOutLookupVm>(_mapper.ConfigurationProvider)
                .GroupBy(e => e.Queue.Id) // TODO: GroupBy if may be null
                .ToDictionaryAsync(e => e.Key, e => e.ToList(), cancellationToken: cancellationToken);

            var response = new WhsOrderOutDictionaryByQueueVm { Orders = orders };
            return response;
        }
    }
}
