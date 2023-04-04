﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductVm>
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            var product = await _dbContext.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Product), request.Id);

            var response = _mapper.Map<ProductVm>(product);

            return response;
        }
    }
}
