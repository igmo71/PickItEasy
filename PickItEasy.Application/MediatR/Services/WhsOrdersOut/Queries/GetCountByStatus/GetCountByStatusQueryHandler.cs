using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.WhsOrder.Out.Search;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.GetCountByStatus
{
    public class GetCountByStatusQueryHandler : IRequestHandler<GetCountByStatusQuery, Dictionary<Guid, int>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetCountByStatusQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<Guid, int>> Handle(GetCountByStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WhsOrdersOut
                .AsNoTracking()
                .Where(e => e.Active)
                .SearchByTerm(request.SearchParameters)
                .GroupBy(e => e.StatusId)
                .Select(e => new { e.Key, Value = e.Count() })
                .ToDictionaryAsync(e => e.Key, e => e.Value, cancellationToken);

            return result;
        }
    }
}
