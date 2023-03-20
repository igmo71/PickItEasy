using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.WhsOrdersOut.Dto;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersExpense.Commands.CreateWhsOrderExpense
{
    public class CreateWhsOrderOutCommandHandler : IRequestHandler<CreateWhsOrderOutCommand, WhsOrderOutDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateWhsOrderOutCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutDto> Handle(CreateWhsOrderOutCommand request, CancellationToken cancellationToken)
        {
            var whsOrderOut = _mapper.Map<WhsOrderOut>(request.CreateWhsOrderExpenseDto);

            await _dbContext.WhsOrdersOut.AddAsync(whsOrderOut);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            var response = _mapper.Map<WhsOrderOutDto>(whsOrderOut);

            return response;
        }
    }
}
