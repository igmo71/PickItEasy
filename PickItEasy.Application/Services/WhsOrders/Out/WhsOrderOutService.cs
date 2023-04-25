using Microsoft.Extensions.Logging;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.WhsOrders.Out;

namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutService : IWhsOrderOutService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<WhsOrderOutService> _logger;

        public WhsOrderOutService(IApplicationDbContext dbContext, ILogger<WhsOrderOutService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<WhsOrderOutDto> Create(WhsOrderOutDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DisableAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WhsOrderOutVm> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountByStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WhsOrderOutDictionaryByQueueVm> GetDictionaryByQueueAsync(SearchParameters SearchParameters)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WhsOrderOutDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
