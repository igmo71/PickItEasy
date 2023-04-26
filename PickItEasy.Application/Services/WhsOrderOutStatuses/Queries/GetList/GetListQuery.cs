using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList
{
    public class GetListQuery : IRequest<WhsOrderOutStatusListVm>
    {
    }
}
