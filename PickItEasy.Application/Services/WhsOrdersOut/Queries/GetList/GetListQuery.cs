using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetListQuery : IRequest<WhsOrderOutListVm>
    {
        public required SearchParameters SearchParameters { get; set; }
    }
}
