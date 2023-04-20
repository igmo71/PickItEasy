using AutoMapper;
using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Services.BaseDocuments.Commands.Create;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.CreateByPack
{
    public class CreateByPackCommandHandler : IRequestHandler<CreateByPackCommand>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateByPackCommandHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(CreateByPackCommand request, CancellationToken cancellationToken)
        {
            foreach (var whsOrderOutBaseDocumentDto in request.WhsOrderOutBaseDocumentDtos)
            {
                var baseDocumentDto = _mapper.Map<BaseDocumentDto>(whsOrderOutBaseDocumentDto);
                _ = await _mediator.Send(new CreateCommand { BaseDocumentDto = baseDocumentDto }, cancellationToken);
            }

            return;
        }
    }
}
