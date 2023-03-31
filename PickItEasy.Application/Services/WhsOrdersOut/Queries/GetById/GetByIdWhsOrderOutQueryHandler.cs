using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutQueryHandler : IRequestHandler<GetByIdWhsOrderOutQuery, WhsOrderOutVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetByIdWhsOrderOutQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutVm> Handle(GetByIdWhsOrderOutQuery request, CancellationToken cancellationToken)
        {
            var whsOrderOut = await _dbContext.WhsOrdersOut.AsNoTracking()
                .Include(e => e.WhsOrderOutProducts).ThenInclude(op => op.Product)//.Include(e => e.Products)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken) 
                ?? throw new EntityNotFoundException(nameof(WhsOrderOut), request.Id);
            
            var response = _mapper.Map<WhsOrderOutVm>(whsOrderOut);

            return response;
        }
    }
}
