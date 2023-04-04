using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList
{
    public class GetWhsOrderOutStatusListQueryHandler : IRequestHandler<GetWhsOrderOutStatusListQuery, List<WhsOrderOutStatus>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetWhsOrderOutStatusListQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<WhsOrderOutStatus>> Handle(GetWhsOrderOutStatusListQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WhsOrderOutStatuses.AsNoTracking().ToListAsync(cancellationToken);
            return result;
        }
    }
}
