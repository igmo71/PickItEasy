using MediatR;

namespace PickItEasy.Application.MediatR.Services.WhsOrderOutStatuses.Queries.Contains
{
    public class ContainsValueQuery : IRequest<bool>
    {
        public int Value { get; set; }
    }
}
