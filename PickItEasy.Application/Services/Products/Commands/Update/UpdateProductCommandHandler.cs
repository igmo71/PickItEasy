using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.Products.Commands.Create;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken) 
                ?? throw new EntityNotFoundException(nameof(Product), request.Id);

            product.Name = request.UpdateProductDto?.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
