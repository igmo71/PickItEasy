using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

public interface IWhsOrderOutStatusService
{
    Task<WhsOrderOutStatusDto> CreateAsync(WhsOrderOutStatusDto dto);
    Task UpdateAsync(WhsOrderOutStatusDto dto);
    Task<Guid> GetIdByValueAsync(int value);
    Task<WhsOrderOutStatusListVm> GetListAsync();
}
