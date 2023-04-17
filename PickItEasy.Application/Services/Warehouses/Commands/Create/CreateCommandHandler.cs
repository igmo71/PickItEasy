using AutoMapper;
using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.Warehouses.Commands.Update;
using PickItEasy.Application.Services.Warehouses.Queries.IsExistsById;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Warehouses.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, WarehouseDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<WarehouseDto> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var warehouse = _mapper.Map<Warehouse>(request.WarehouseDto);

            var isExists = await _mediator.Send(new IsExistsByIdQuery { Id = request.WarehouseDto.Id }, cancellationToken);
            if (isExists)
            {
                await _mediator.Send(new UpdateCommand
                {
                    Id = warehouse.Id,
                    WarehouseDto = request.WarehouseDto
                }, cancellationToken);
            }
            else
            {
                warehouse.Active = true;
                await _dbContext.Warehouses.AddAsync(warehouse, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            
            return request.WarehouseDto;
        }
    }
}
