using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Products.Commands.Disable
{
    public class DisableCommandHandler : IRequestHandler<DisableCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DisableCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DisableCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == request.Id)
                ?? throw new EntityNotFoundException(nameof(Product), request.Id);

            product.Active = false;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
