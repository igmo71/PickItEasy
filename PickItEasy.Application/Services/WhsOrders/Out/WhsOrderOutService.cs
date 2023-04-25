﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.WhsOrders.Out;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutService : IWhsOrderOutService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<WhsOrderOutService> _logger;
        private readonly IBaseDocumentService _baseDocumentService;
        private readonly IWhsOrderOutStatusService _statusService;
        private readonly IWhsOrderOutQueueService _queueService;

        public WhsOrderOutService(IApplicationDbContext dbContext, ILogger<WhsOrderOutService> logger, IBaseDocumentService baseDocumentService, IWhsOrderOutStatusService statusService, IWhsOrderOutQueueService queueService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _baseDocumentService = baseDocumentService;
            _statusService = statusService;
            _queueService = queueService;

        }

        public async Task<WhsOrderOutDto> CreateAsync(WhsOrderOutDto dto)
        {
            await _baseDocumentService.CreateRangeAsync(dto.BaseDocuments);

            WhsOrderOut whsOrder = WhsOrderOutMapper.Map(dto);

            whsOrder.StatusId = await _statusService.GetIdByValueAsync(dto.Status);
            whsOrder.QueueId = await _queueService.GetIdByValueAsync(dto.Queue);

            var isExists = await IsExistsByIdAsync(dto.Id);
            if(isExists)
            {
                await DeleteAsync(dto.Id);
            }
            await _dbContext.WhsOrdersOut.AddAsync(whsOrder);
            await _dbContext.SaveChangesAsync();

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            WhsOrderOut whsOrder = await _dbContext.WhsOrdersOut
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(WhsOrderOut), id);

            _dbContext.WhsOrdersOut.Remove(whsOrder);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DisableAsync(Guid id)
        {
            WhsOrderOut whsOrder = await _dbContext.WhsOrdersOut
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(WhsOrderOut), id);

            whsOrder.Active = false;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<WhsOrderOutVm> GetByIdAsync(Guid id)
        {
            WhsOrderOut whsOrderOut = await _dbContext.WhsOrdersOut
                .AsNoTracking()
                .Include(e => e.Warehouse)
                .Include(e => e.WhsOrderOutProducts).ThenInclude(op => op.Product)//.Include(e => e.Products)
                .Include(e => e.WhsOrderOutBaseDocuments).ThenInclude(ob => ob.BaseDocument)
                .Include(e => e.Status)
                .Include(e => e.Queue)
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(WhsOrderOut), id);

            var result = WhsOrderOutMapper.Map(whsOrderOut);

            return result;
        }

        public async Task<Dictionary<Guid, int>> GetCountByStatusAsync(SearchParameters searchParameters)
        {
            var result = await _dbContext.WhsOrdersOut
                .AsNoTracking()
                .Where(e => e.Active)
                .SearchByTerm(searchParameters)
                .GroupBy(e => e.StatusId)
                .Select(e => new { Key = e.Key, Value = e.Count() })
                .ToDictionaryAsync(e => e.Key, e => e.Value);

            return result;
        }

        public async Task<WhsOrderOutDictionaryByQueueVm> GetDictionaryByQueueAsync(SearchParameters searchParameters)
        {
            List<WhsOrderOut> orderList = await _dbContext.WhsOrdersOut
                .AsNoTracking()
                .Where(e => e.Active)
                .SearchByTerm(searchParameters)
                .SearchByStatus(searchParameters)
                .OrderBy(e => e.StatusId)
                    .ThenBy(e => e.QueueId)
                    .ThenByDescending(e => e.ShipDateTime)
                .ToListAsync();

            List<WhsOrderOutLookupVm> orderLookupList = WhsOrderOutMapper.Map(orderList);
                        
            Dictionary<Guid, List<WhsOrderOutLookupVm>> orderDictionary = orderLookupList
                .GroupBy(e => e.Queue.Id) // TODO: GroupBy if may be null
                .ToDictionary(e => e.Key, e => e.ToList());

            var result = new WhsOrderOutDictionaryByQueueVm { Orders = orderDictionary };

            return result;
        }

        public async Task<bool> IsExistsByIdAsync(Guid id)
        {
            var result = await _dbContext.WhsOrdersOut.AnyAsync(e => e.Id == id);
            return result;
        }
    }
}
