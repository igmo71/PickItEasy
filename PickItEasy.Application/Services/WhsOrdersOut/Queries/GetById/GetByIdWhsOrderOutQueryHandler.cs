using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.WhsOrdersOut.Dto;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .FirstOrDefaultAsync(e => e.Id == request.Id);

            if (whsOrderOut == null) throw new EntityNotFoundException(nameof(WhsOrderOut), request.Id);

            var response = _mapper.Map<WhsOrderOutVm>(whsOrderOut);

            return response;
        }
    }
}
