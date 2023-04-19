using MediatR;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.Contains
{
    public class ContainsValueQuery : IRequest<bool>
    {
        public int Value { get; set; }
    }
}
