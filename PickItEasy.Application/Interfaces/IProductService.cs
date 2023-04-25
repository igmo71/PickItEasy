using PickItEasy.Application.Services.Products;

namespace PickItEasy.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(ProductDto dto);
        Task DeleteAsync(Guid id);
        Task DisableAsync(Guid id);
        Task<ProductVm> GetByIdAsync(Guid id);
        Task<bool> IsExistsByIdAsync(Guid id);
        Task UpdateAsync(ProductDto dto);

    }
}
