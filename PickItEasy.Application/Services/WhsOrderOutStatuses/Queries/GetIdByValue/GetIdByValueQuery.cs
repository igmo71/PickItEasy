using MediatR;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetIdByValue
{
    public class GetIdByValueQuery : IRequest<Guid>
    {
        public int Value { get; set; }
    }
}
