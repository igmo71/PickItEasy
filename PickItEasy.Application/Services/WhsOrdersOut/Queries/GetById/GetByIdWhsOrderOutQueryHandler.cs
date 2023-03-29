using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutQueryHandler : IRequestHandler<GetByIdWhsOrderOutQuery, GetByIdWhsOrderOutVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetByIdWhsOrderOutQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetByIdWhsOrderOutVm> Handle(GetByIdWhsOrderOutQuery request, CancellationToken cancellationToken)
        {
            var whsOrderOut = await _dbContext.WhsOrdersOut.AsNoTracking()
                .Include(e => e.WhsOrderOutProducts).ThenInclude(op => op.Product)
                //.Include(e => e.Products)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

            if (whsOrderOut == null) throw new EntityNotFoundException(nameof(WhsOrderOut), request.Id);

            var response = _mapper.Map<GetByIdWhsOrderOutVm>(whsOrderOut);

            return response;
        }
    }
}
