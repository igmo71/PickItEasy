using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetWhsOrderOutListQueryHandler : IRequestHandler<GetWhsOrderOutListQuery, WhsOrderOutListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWhsOrderOutListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutListVm> Handle(GetWhsOrderOutListQuery request, CancellationToken cancellationToken)
        {
            var whsOrdersOut = await _dbContext.WhsOrdersOut
                .AsNoTracking()
                .Search(request.SearchParameters)
                .ProjectTo<WhsOrderOutLookupVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var response = new WhsOrderOutListVm { Orders = whsOrdersOut };
            return response;
        }
    }
}
