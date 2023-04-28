using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Application.Services.WhsOrder.Out
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

        public Task<WhsOrderOutStatusDto> CreateAsync(WhsOrderOutStatusDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetIdByValueAsync(int value)
        {
            WhsOrderOutStatus status = await _dbContext.WhsOrderOutStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Value == value)
                ?? throw new NotFoundException(nameof(WhsOrderOutStatus), value);

            return status.Id;
        }

        public async Task<WhsOrderOutStatusListVm> GetListAsync()
        {
            List<WhsOrderOutStatusVm> statuses = await _dbContext.WhsOrderOutStatuses
                .AsNoTracking()
                .Where(s => s.Active)
                .OrderBy(s => s.Value)
                .ProjectToType<WhsOrderOutStatusVm>()
                .ToListAsync();

            WhsOrderOutStatusListVm result = new() { Statuses = statuses };

            return result;
        }

        public Task UpdateAsync(WhsOrderOutStatusDto dto)
        {
            throw new NotImplementedException();
        }


    }
}
