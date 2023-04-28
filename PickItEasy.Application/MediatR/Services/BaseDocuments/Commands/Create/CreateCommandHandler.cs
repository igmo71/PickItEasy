using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Models.BaseDocuments;
using PickItEasy.Application.Services.BaseDocuments.Commands.Update;
using PickItEasy.Application.Services.BaseDocuments.Queries.IsExistsById;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.MediatR.Services.BaseDocuments.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, BaseDocumentDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BaseDocumentDto> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var baseDocument = _mapper.Map<BaseDocument>(request.BaseDocumentDto);

            var isBaseDocumentExists = await _mediator.Send(new IsExistsByIdQuery { Id = baseDocument.Id }, cancellationToken);
            if (isBaseDocumentExists)
            {
                await _mediator.Send(new UpdateCommand
                {
                    Id = baseDocument.Id,
                    BaseDocumentDto = request.BaseDocumentDto
                }, cancellationToken);
            }
            else
            {
                await _dbContext.BaseDocuments.AddAsync(baseDocument, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return request.BaseDocumentDto;
        }
    }
}
