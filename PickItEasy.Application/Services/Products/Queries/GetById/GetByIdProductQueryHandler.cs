﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.Products.Vm;
using PickItEasy.Application.Services.WhsOrdersOut.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductVm>
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {

            var product = await _dbContext.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id);
                ?? throw new EntityNotFoundException(nameof(Product), request.Id); ;

            if (product == null) throw new EntityNotFoundException();

            var response = _mapper.Map<ProductVm>(product);

            return response;
        }
    }
}
