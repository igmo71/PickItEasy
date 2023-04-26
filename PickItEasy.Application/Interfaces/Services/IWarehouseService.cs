using PickItEasy.Application.Models.Warehouses;

namespace PickItEasy.Application.Interfaces.Services
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
