using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, WhsOrderOutVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutVm> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var whsOrderOut = await _dbContext.WhsOrdersOut.AsNoTracking()
                .Include(e => e.Warehouse)
                .Include(e => e.WhsOrderOutProducts).ThenInclude(op => op.Product)//.Include(e => e.Products)
                .Include(e => e.WhsOrderOutBaseDocuments).ThenInclude(ob => ob.BaseDocument)
                .Include(e => e.Status)
                .Include(e => e.Queue)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken)
                ?? throw new EntityNotFoundException(nameof(WhsOrderOut), request.Id);

            var response = _mapper.Map<WhsOrderOutVm>(whsOrderOut);

            return response;
        }
    }
}
