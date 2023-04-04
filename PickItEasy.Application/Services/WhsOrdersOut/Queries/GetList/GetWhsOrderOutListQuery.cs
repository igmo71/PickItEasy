using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetWhsOrderOutListQuery : IRequest<WhsOrderOutListVm>
    {
        public required WhsOrderOutSearchParameters SearchParameters { get; set; }
    }
}
