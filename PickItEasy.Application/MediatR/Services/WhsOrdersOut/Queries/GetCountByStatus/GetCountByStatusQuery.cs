using MediatR;
using PickItEasy.Application.MediatR.Services.WhsOrder.Out.Search;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.GetCountByStatus
{
    public class GetCountByStatusQuery : IRequest<Dictionary<Guid, int>>
    {
        public required SearchParameters SearchParameters { get; set; }
    }
}
