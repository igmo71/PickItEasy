using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Queries.IsExistsById
{
    public class IsExistsByIdProductQueryHandler : IRequestHandler<IsExistsByIdProductQuery, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public IsExistsByIdProductQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(IsExistsByIdProductQuery request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Products.AnyAsync(p => p.Id == request.Id, cancellationToken);

            return response;
        }
    }
}
