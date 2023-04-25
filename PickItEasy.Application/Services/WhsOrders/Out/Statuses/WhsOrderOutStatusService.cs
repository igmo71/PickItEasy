using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.WhsOrders.Out;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out.Statuses
{
    public class WhsOrderOutStatusService : IWhsOrderOutStatusService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<WhsOrderOutStatusService> _logger;

        public WhsOrderOutStatusService(IApplicationDbContext dbContext, ILogger<WhsOrderOutStatusService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<WhsOrderOutStatusVm> CreateAsync(WhsOrderOutStatusDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetIdByValueAsync(int value)
        {
            var status = await _dbContext.WhsOrderOutStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Value == value)
                ?? throw new NotFoundException(nameof(WhsOrderOutStatus), value);

            return status.Id;
        }

        public async Task<WhsOrderOutStatusListVm> GetListAsync()
        {
            List<WhsOrderOutStatus> statuses = await _dbContext.WhsOrderOutStatuses
                .AsNoTracking()
                .Where(s => s.Active)
                .OrderBy(s => s.Value)
                .ToListAsync();

            var result = WhsOrderOutStatusMapper.Map(statuses);

            return result;
        }

        public Task UpdateAsync(WhsOrderOutStatusDto dto)
        {
            throw new NotImplementedException();
        }


    }
}
