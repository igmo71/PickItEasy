using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetDictionaryByQueue
{
    public class GetDictionaryByQueueQuery : IRequest<WhsOrderOutDictionaryByQueueVm>
    {
        public required SearchParameters SearchParameters { get; set; }
    }
}
