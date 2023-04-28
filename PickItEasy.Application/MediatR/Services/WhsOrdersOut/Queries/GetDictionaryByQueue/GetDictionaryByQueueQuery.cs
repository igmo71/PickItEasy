using MediatR;
using PickItEasy.Application.MediatR.Services.WhsOrder.Out.Search;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.GetDictionaryByQueue
{
    public class GetDictionaryByQueueQuery : IRequest<WhsOrderOutDictionaryByQueueVm>
    {
        public required SearchParameters SearchParameters { get; set; }
    }
}
