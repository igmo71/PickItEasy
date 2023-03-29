using AutoMapper;
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

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductVm>
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetByIdProductVm> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {

            var product = await _dbContext.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Product), request.Id);
            
            var response = _mapper.Map<GetByIdProductVm>(product);

            return response;
        }
    }
}
