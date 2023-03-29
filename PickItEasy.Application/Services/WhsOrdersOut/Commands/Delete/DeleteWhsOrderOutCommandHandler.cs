using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteWhsOrderOutCommandHandler : IRequestHandler<DeleteWhsOrderOutCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteWhsOrderOutCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteWhsOrderOutCommand request, CancellationToken cancellationToken)
        {
            var whsOrderOut = await _dbContext.WhsOrdersOut
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken)
                ?? throw new EntityNotFoundException(nameof(WhsOrdersOut), request.Id);

            _dbContext.WhsOrdersOut.Remove(whsOrderOut);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
