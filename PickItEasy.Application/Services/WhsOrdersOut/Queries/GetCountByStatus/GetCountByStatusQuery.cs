using MediatR;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetCountByStatus
{
    public class GetCountByStatusQuery : IRequest<Dictionary<Guid, int>>
    {
        public required SearchParameters SearchParameters { get; set; }
    }
}
