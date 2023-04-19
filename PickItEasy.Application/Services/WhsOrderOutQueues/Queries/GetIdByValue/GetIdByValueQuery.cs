using MediatR;

namespace PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetIdByValue
{
    public class GetIdByValueQuery : IRequest<Guid>
    {
        public int Value { get; set; }
    }
}
