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

            product.IsActive = false;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
