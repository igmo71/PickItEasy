using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.WhsOrdersOut.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class GetWhsOrderOutQueryHandler : IRequestHandler<GetWhsOrderOutQuery, WhsOrderOutDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWhsOrderOutQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutDto> Handle(GetWhsOrderOutQuery request, CancellationToken cancellationToken)
        {
            var whsOrderOut = await _dbContext.WhsOrdersOut.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id);

            if (whsOrderOut == null) throw new EntityNotFoundException();

            var response = _mapper.Map<WhsOrderOutDto>(whsOrderOut);

            return response;
        }
    }
}
