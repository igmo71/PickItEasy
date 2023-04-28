using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Interfaces.Integration.WhsOrder.Out
{
    public interface IWhsOrderOutService
    {
        Task<string> PostOrder(WhsOrderOutVm whsOrderOutVm);
    }
}
