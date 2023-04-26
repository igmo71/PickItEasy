using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;
using PickItEasy.Application.Services.WhsOrder.Out.Search;

namespace PickItEasy.Application.Interfaces.Services.WhsOrder.Out
{
    public interface IWhsOrderOutService
    {
        Task<WhsOrderOutDto> CreateAsync(WhsOrderOutDto dto);
        Task DeleteAsync(Guid id);
        Task DisableAsync(Guid id);
        Task<WhsOrderOutVm> GetByIdAsync(Guid id);
        Task<Dictionary<Guid, int>> GetCountByStatusAsync(SearchParameters searchParameters);
        Task<WhsOrderOutDictionaryByQueueVm> GetDictionaryByQueueAsync(SearchParameters searchParameters);
        Task<bool> IsExistsByIdAsync(Guid id);
    }
}
