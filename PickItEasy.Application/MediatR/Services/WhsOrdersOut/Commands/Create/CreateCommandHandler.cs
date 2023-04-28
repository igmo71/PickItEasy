using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.MediatR.Services.WhsOrdersOut.Commands.Delete;
using PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.IsExistsById;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Commands.Create
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
            await CreateBaseDocumentsByPack(request.WhsOrderOutDto.BaseDocuments);

            var whsOrder = _mapper.Map<WhsOrderOut>(request.WhsOrderOutDto);

            whsOrder.StatusId = await _mediator.Send(
                new WhsOrderOutStatuses.Queries.GetIdByValue.GetIdByValueQuery { Value = request.WhsOrderOutDto.Status }, cancellationToken);

            whsOrder.QueueId = await _mediator.Send(
                new WhsOrderOutQueues.Queries.GetIdByValue.GetIdByValueQuery { Value = request.WhsOrderOutDto.Queue }, cancellationToken);

            var isExists = await _mediator.Send(new IsExistsByIdQuery { Id = whsOrder.Id }, cancellationToken);
            if (isExists)
            {
                await _mediator.Send(new DeleteCommand { Id = whsOrder.Id }, cancellationToken);
            }
            await _dbContext.WhsOrdersOut.AddAsync(whsOrder, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return request.WhsOrderOutDto;
        }

        private async Task CreateBaseDocumentsByPack(List<WhsOrderOutBaseDocumentDto>? whsOrderOutBaseDocumentDtos)
        {
            if (whsOrderOutBaseDocumentDtos != null && whsOrderOutBaseDocumentDtos.Count != 0)
            {
                await _mediator.Send(
                    new BaseDocuments.Commands.CreateByPack.CreateByPackCommand { WhsOrderOutBaseDocumentDtos = whsOrderOutBaseDocumentDtos });
            }
        }
    }
}
