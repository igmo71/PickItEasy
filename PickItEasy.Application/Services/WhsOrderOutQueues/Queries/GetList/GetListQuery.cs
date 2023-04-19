using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetList
{
    public class GetListQuery : IRequest<WhsOrderOutQueueListVm>
    {
    }
}
