using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.Application.Services.Products.Queries.IsExistsById
{
    public class IsExistsByIdProductQueryHandler : IRequestHandler<IsExistsProductByIdQuery, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public IsExistsByIdProductQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(IsExistsProductByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Products.AnyAsync(p => p.Id == request.Id, cancellationToken);
            return response;
        }
    }
}
