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
    public class CreateCommandHandler : IRequestHandler<CreateCommand, WhsOrderOutDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator/*, IEventBusPublisher eventPublisher*/)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<WhsOrderOutDto> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var whsOrder = _mapper.Map<WhsOrderOut>(request.WhsOrderOutDto);

            whsOrder.StatusId = await _mediator.Send(new GetIdByValueQuery { Value = request.WhsOrderOutDto.Status }, cancellationToken);
            whsOrder.QueueId = Guid.Parse("7e83260a-316f-4a1f-be9a-bf353b118536");

            var isExists = await _mediator.Send(new IsExistsByIdQuery { Id = whsOrder.Id }, cancellationToken);
            if (isExists)
            {
                await _mediator.Send(new DeleteCommand { Id = whsOrder.Id }, cancellationToken);
            }
            await _dbContext.WhsOrdersOut.AddAsync(whsOrder, cancellationToken);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return request.WhsOrderOutDto;
        }
    }
}
