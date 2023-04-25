using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.WhsOrders.Out;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutStatusService : IWhsOrderStatusService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<WhsOrderOutStatusService> _logger;

        public WhsOrderOutStatusService(IApplicationDbContext dbContext, ILogger<WhsOrderOutStatusService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<WhsOrderOutStatusVm> Create(WhsOrderOutStatusDto orderOutStatusDto)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> GetIdByValue(int value)
        {
            throw new NotImplementedException();
        }

        public async Task<WhsOrderOutStatusListVm> GetList()
        {
            List<WhsOrderOutStatus> statuses = await _dbContext.WhsOrderOutStatuses
                .AsNoTracking()
                .Where(s => s.Active)
                .OrderBy(s => s.Value)
                .ToListAsync();

            var result = Map(statuses);

            return result;
        }

        public Task Update(WhsOrderOutStatusDto orderOutStatusDto)
        {
            throw new NotImplementedException();
        }

        public static WhsOrderOutStatusVm Map(WhsOrderOutStatus source)
        {
            WhsOrderOutStatusVm destination = new WhsOrderOutStatusVm
            {
                Id = source.Id,
                Name = source.Name,
                Synonym = source.Synonym,
                Value = source.Value,
                Active = source.Active
            };

            return destination;
        }

        public static WhsOrderOutStatusListVm Map(List<WhsOrderOutStatus> source)
        {
            WhsOrderOutStatusListVm destination = new()
            {
                Statuses = new()
            };

            foreach (var item in source)
            {
                destination.Statuses.Add(Map(item));
            }

            return destination;
        }
    }
}
