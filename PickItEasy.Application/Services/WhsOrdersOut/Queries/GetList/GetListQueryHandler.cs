using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, WhsOrderOutListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutListVm> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.WhsOrdersOut//.Include(o => o.Status)
                .AsNoTracking()
                .Search(request.SearchParameters)
                .ProjectTo<WhsOrderOutLookupVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var response = new WhsOrderOutListVm { Orders = orders };
            return response;
        }
    }
}
