using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetIdByValue
{
    public class GetIdByValueQueryHandler : IRequestHandler<GetIdByValueQuery, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetIdByValueQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(GetIdByValueQuery request, CancellationToken cancellationToken)
        {
            var status = await _dbContext.WhsOrderOutStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Value == request.Value, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(WhsOrderOutStatus), request.Value.ToString());
            return status.Id;
        }
    }
}
