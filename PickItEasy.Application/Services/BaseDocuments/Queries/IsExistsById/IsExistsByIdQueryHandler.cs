using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.Application.Services.BaseDocuments.Queries.IsExistsById
{
    public class IsExistsByIdQueryHandler : IRequestHandler<IsExistsByIdQuery, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public IsExistsByIdQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(IsExistsByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.BaseDocuments.AnyAsync(p => p.Id == request.Id, cancellationToken);
            return response;
        }
    }
}
