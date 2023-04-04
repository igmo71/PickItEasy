using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, WhsOrderOutStatusListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<WhsOrderOutStatusListVm> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var statuses = await _dbContext.WhsOrderOutStatuses
                .AsNoTracking()
                .Where(s => s.IsActive)
                .ProjectTo<WhsOrderOutStatusVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var response = new WhsOrderOutStatusListVm { Statuses = statuses};
            return response;
        }
    }
}
