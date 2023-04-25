using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.WhsOrders.Out;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out.Queues
{
    public class WhsOrderOutQueueService : IWhsOrderOutQueueService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<WhsOrderOutQueueService> _logger;

        public WhsOrderOutQueueService(IApplicationDbContext dbContext, ILogger<WhsOrderOutQueueService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Task<WhsOrderOutQueueVm> CreateAsync(WhsOrderOutQueueDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetIdByValueAsync(int value)
        {
            var queue = await _dbContext.WhsOrderOutQueues
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Value == value)
                ?? throw new NotFoundException(nameof(WhsOrderOutQueue), value);

            return queue.Id;
        }

        public async Task<WhsOrderOutQueueListVm> GetListAsync()
        {
            List<WhsOrderOutQueue> queues = await _dbContext.WhsOrderOutQueues
               .AsNoTracking()
               .Where(s => s.Active)
               .OrderBy(s => s.Value)
               .ToListAsync();

            var result = WhsOrderOutQueueMapper.Map(queues);

            return result;
        }

        public Task UpdateAsync(WhsOrderOutQueueDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
