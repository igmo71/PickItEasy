using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Interfaces.Services.WhsOrder.Out
{
    public interface IWhsOrderOutQueueService
    {
        Task<WhsOrderOutQueueDto> CreateAsync(WhsOrderOutQueueDto dto);
        Task UpdateAsync(WhsOrderOutQueueDto dto);
        Task<Guid> GetIdByValueAsync(int value);
        Task<WhsOrderOutQueueListVm> GetListAsync();
    }
}
