using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var baseDocument = await _dbContext.BaseDocuments
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (baseDocument is null || baseDocument.Id != request.Id)
                throw new EntityNotFoundException(nameof(BaseDocument), request.Id);

            baseDocument.Name = request.BaseDocumentDto.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
