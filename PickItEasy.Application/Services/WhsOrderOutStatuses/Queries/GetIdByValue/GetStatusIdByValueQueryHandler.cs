using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetIdByValue
{
    public class GetStatusIdByValueQueryHandler : IRequestHandler<GetStatusIdByValueQuery, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetStatusIdByValueQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(GetStatusIdByValueQuery request, CancellationToken cancellationToken)
        {
            var status = await _dbContext.WhsOrderOutStatuses.FirstOrDefaultAsync(e => e.Value == request.Value)
                ?? throw new EntityNotFoundException(nameof(WhsOrderOutStatus), request.Value.ToString());
            return status.Id;
        }
    }
}
