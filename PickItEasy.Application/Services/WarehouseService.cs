using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.Services;
using PickItEasy.Application.Models.Warehouses;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<WarehouseService> _logger;

        public WarehouseService(IApplicationDbContext dbContext, ILogger<WarehouseService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<WarehouseDto> CreateAsync(WarehouseDto dto)
        {
            Warehouse warehouse = dto.Adapt<Warehouse>();

            bool isWarehouseExists = await IsExistsByIdAsync(warehouse.Id);
            if (isWarehouseExists)
            {
                await UpdateAsync(dto);
            }
            else
            {
                await _dbContext.Warehouses.AddAsync(warehouse);
                await _dbContext.SaveChangesAsync();
            }

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            Warehouse warehouse = await _dbContext.Warehouses.FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(Warehouse), id);

            _dbContext.Warehouses.Remove(warehouse);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DisableAsync(Guid id)
        {
            Warehouse warehouse = await _dbContext.Warehouses.FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(Warehouse), id);

            warehouse.Active = false;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<WarehouseVm> GetByIdAsync(Guid id)
        {
            Warehouse warehouse = await _dbContext.Warehouses
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(Warehouse), id);

            WarehouseVm result = warehouse.Adapt<WarehouseVm>();

            return result;
        }

        public async Task<bool> IsExistsByIdAsync(Guid id)
        {
            bool result = await _dbContext.Warehouses.AnyAsync(p => p.Id == id);

            return result;
        }

        public async Task UpdateAsync(WarehouseDto dto)
        {
            Warehouse? warehouse = await _dbContext.Warehouses
                .FirstOrDefaultAsync(e => e.Id == dto.Id);

            if (warehouse is null || warehouse.Id != dto.Id)
                throw new NotFoundException(nameof(Warehouse), dto.Id);

            warehouse.Name = dto.Name;
            warehouse.Active = dto.Active;

            await _dbContext.SaveChangesAsync();
        }
    }
}
