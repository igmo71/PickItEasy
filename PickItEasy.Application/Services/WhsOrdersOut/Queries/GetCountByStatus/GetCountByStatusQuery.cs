using MediatR;
using PickItEasy.Application.Services.WhsOrder.Out.Search;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetCountByStatus
{
    public class GetCountByStatusQuery : IRequest<Dictionary<Guid, int>>
    {
        public required SearchParameters SearchParameters { get; set; }
    }
}
