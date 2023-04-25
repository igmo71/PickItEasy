using PickItEasy.Application.Services.WhsOrders.Out.Statuses;

namespace PickItEasy.Application.Interfaces.WhsOrders.Out
{
    public interface IWhsOrderOutStatusService
    {
        Task<WhsOrderOutStatusVm> CreateAsync(WhsOrderOutStatusDto dto);
        Task UpdateAsync(WhsOrderOutStatusDto dto);
        Task<Guid> GetIdByValueAsync(int value);
        Task<WhsOrderOutStatusListVm> GetListAsync();
    }
}
