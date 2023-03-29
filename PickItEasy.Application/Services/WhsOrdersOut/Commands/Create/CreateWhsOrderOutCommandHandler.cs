using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommandHandler : IRequestHandler<CreateWhsOrderOutCommand, CreateWhsOrderOutVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IEventBusPublisher _eventPublisher;

        public CreateWhsOrderOutCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IEventBusPublisher eventPublisher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
        }

        public async Task<CreateWhsOrderOutVm> Handle(CreateWhsOrderOutCommand request, CancellationToken cancellationToken)
        {
            var whsOrderOut = _mapper.Map<WhsOrderOut>(request.CreateWhsOrderOutDto);

            await _dbContext.WhsOrdersOut.AddAsync(whsOrderOut);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            _eventPublisher.SendMessage($"{nameof(whsOrderOut)}_{whsOrderOut.Id}");

            var response = _mapper.Map<CreateWhsOrderOutVm>(whsOrderOut);

            return response;
        }
    }
}
