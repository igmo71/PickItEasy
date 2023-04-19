using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.Create
{
    public class CreateCommand : IRequest<BaseDocumentDto>
    {
        public required BaseDocumentDto BaseDocumentDto { get; set; }
    }
}
