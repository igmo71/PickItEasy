using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.MediatR.Services.Warehouses.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _dbContext.Warehouses
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

            if (warehouse == null || warehouse.Id != request.Id)
                throw new EntityNotFoundException(nameof(Warehouse), request.Id);

            warehouse.Name = request.WarehouseDto.Name;
            warehouse.Active = request.WarehouseDto.Active;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
