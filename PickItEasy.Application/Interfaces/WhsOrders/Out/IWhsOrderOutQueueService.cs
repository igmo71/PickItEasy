using PickItEasy.Application.Services.WhsOrders.Out.Queues;

namespace PickItEasy.Application.Interfaces.WhsOrders.Out
{
    public interface IWhsOrderOutQueueService
    {
        Task<WhsOrderOutQueueDto> CreateAsync(WhsOrderOutQueueDto dto);
        Task UpdateAsync(WhsOrderOutQueueDto dto);
        Task<Guid> GetIdByValueAsync(int value);
        Task<WhsOrderOutQueueListVm> GetListAsync();
    }
}
