using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetListWhsOrderOutQueryHandler : IRequestHandler<GetListWhsOrderOutQuery, GetListWhsOrderOutVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListWhsOrderOutQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetListWhsOrderOutVm> Handle(GetListWhsOrderOutQuery request, CancellationToken cancellationToken)
        {
            var whsOrdersOut = await _dbContext.WhsOrdersOut
                .AsNoTracking()
                .Search(request.SearchParameters)
                .ProjectTo<GetListWhsOrderOutLookup>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var response = new GetListWhsOrderOutVm { Orders = whsOrdersOut };
            return response;
        }
    }
}
