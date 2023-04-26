using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetList
{
    public class GetListQuery : IRequest<WhsOrderOutQueueListVm>
    {
    }
}
