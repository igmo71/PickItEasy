using MediatR;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.CreateByPack
{
    public class CreateByPackCommand : IRequest
    {
        public required List<WhsOrderOutBaseDocumentDto> WhsOrderOutBaseDocumentDtos { get; set; }
    }
}
