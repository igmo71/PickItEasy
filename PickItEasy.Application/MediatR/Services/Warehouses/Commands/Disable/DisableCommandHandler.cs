using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.MediatR.Services.Warehouses.Commands.Disable
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
            var warehouse = await _dbContext.Warehouses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Product), request.Id);

            warehouse.Active = false;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
