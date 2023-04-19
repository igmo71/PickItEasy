using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Warehouses.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _dbContext.Warehouses.FirstOrDefaultAsync(e => e.Id == request.WarehouseDto.Id)
                ?? throw new EntityNotFoundException(nameof(Product), request.WarehouseDto.Id);

            _dbContext.Warehouses.Remove(warehouse);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
