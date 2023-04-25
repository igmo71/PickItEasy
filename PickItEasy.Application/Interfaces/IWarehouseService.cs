using PickItEasy.Application.Services.Warehouses;

namespace PickItEasy.Application.Interfaces
{
    public interface IWarehouseService
    {
        Task<WarehouseDto> CreateAsync(WarehouseDto dto);
        Task DeleteAsync(Guid id);
        Task DisableAsync(Guid id);
        Task<WarehouseVm> GetByIdAsync(Guid id);
        Task<bool> IsExistsByIdAsync(Guid id);
        Task UpdateAsync(WarehouseDto dto);
    }
}
