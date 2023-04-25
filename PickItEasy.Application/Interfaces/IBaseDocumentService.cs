using PickItEasy.Application.Services.BaseDocuments;
using PickItEasy.Application.Services.WhsOrders.Out;

namespace PickItEasy.Application.Interfaces
{
    public interface IBaseDocumentService
    {
        Task<BaseDocumentDto> CreateAsync(BaseDocumentDto dto);
        Task UpdateAsync(BaseDocumentDto dto);
        Task CreateRangeAsync(List<WhsOrderOutBaseDocumentDto> dtoList);
        Task<bool> IsExistsByIdAsync(Guid id);
    }
}
