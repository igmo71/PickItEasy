using MediatR;

namespace PickItEasy.Application.MediatR.Services.WhsOrderOutStatuses.Queries.GetIdByValue
{
    public class GetIdByValueQuery : IRequest<Guid>
    {
        public int Value { get; set; }
    }
}
