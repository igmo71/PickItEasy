using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetIdByValue;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.IsExistsById;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommandHandler : IRequestHandler<CreateWhsOrderOutCommand, WhsOrderOutDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        //private readonly IEventBusPublisher _eventPublisher;

        public CreateWhsOrderOutCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator/*, IEventBusPublisher eventPublisher*/)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
            //_eventPublisher = eventPublisher;
        }

        public async Task<WhsOrderOutDto> Handle(CreateWhsOrderOutCommand request, CancellationToken cancellationToken)
        {
            var whsOrderOut = _mapper.Map<WhsOrderOut>(request.WhsOrderOutDto);

            whsOrderOut.StatusId = await _mediator.Send(new GetWhsOrderOutStatusIdByValueQuery { Value = request.WhsOrderOutDto.Status }, cancellationToken);

            var isWhsOrderOutExists = await _mediator.Send(new IsExistsByIdWhsOrderOutQuery { Id = whsOrderOut.Id }, cancellationToken);
            if (isWhsOrderOutExists)
            {
                await _mediator.Send(new DeleteWhsOrderOutCommand { Id = whsOrderOut.Id }, cancellationToken);
            }
            await _dbContext.WhsOrdersOut.AddAsync(whsOrderOut, cancellationToken);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            //_eventPublisher.SendMessage($"{nameof(whsOrderOut)}_{whsOrderOut.Id}");

            return request.WhsOrderOutDto;
        }
    }
}
