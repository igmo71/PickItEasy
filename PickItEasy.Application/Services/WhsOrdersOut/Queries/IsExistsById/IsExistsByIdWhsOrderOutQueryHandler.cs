using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.IsExistsById
{
    public class IsExistsByIdWhsOrderOutQueryHandler : IRequestHandler<IsExistsByIdWhsOrderOutQuery, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public IsExistsByIdWhsOrderOutQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(IsExistsByIdWhsOrderOutQuery request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.WhsOrdersOut.AnyAsync(e => e.Id == request.Id, cancellationToken);
            return response;
        }
    }
}
