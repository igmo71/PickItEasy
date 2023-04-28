using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Models.Warehouses;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.MediatR.Services.Warehouses.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, WarehouseVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WarehouseVm> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _dbContext.Warehouses
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Product), request.Id);

            var response = _mapper.Map<WarehouseVm>(warehouse);

            return response;
        }
    }
}
