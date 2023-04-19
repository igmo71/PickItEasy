using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList
{
    public class GetListQuery : IRequest<WhsOrderOutStatusListVm>
    {
    }
}
