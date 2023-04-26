using PickItEasy.Application.Models.BaseDocuments;

namespace PickItEasy.Application.Interfaces.Services
{
    public interface IBaseDocumentService
    {
        Task<BaseDocumentDto> CreateAsync(BaseDocumentDto dto);
        Task UpdateAsync(BaseDocumentDto dto);
        Task CreateRangeAsync(List<BaseDocumentDto> dtoList);
        Task<bool> IsExistsByIdAsync(Guid id);
    }
}
