using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;
using PickItEasy.Application.Services.WhsOrder.Out.Search;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.GetDictionaryByQueue
{
    public class GetDictionaryByQueueQuery : IRequest<WhsOrderOutDictionaryByQueueVm>
    {
        public required SearchParameters SearchParameters { get; set; }
    }
}
