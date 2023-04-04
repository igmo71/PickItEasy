using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete
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
            var whsOrder = await _dbContext.WhsOrdersOut
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken)
                ?? throw new EntityNotFoundException(nameof(WhsOrdersOut), request.Id);

            _dbContext.WhsOrdersOut.Remove(whsOrder);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
