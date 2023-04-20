using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetCountByStatus
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
                .SearchCountByStatus(request.SearchParameters)
                .GroupBy(e => e.StatusId)
                .Select(e => new { Key = e.Key, Value = e.Count() })
                .ToDictionaryAsync(e => e.Key, e => e.Value);

            return result;
        }
    }
}
