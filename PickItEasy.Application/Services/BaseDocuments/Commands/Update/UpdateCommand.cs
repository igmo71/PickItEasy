using MediatR;
using PickItEasy.Application.Models.BaseDocuments;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required BaseDocumentDto BaseDocumentDto { get; set; }
    }
}
