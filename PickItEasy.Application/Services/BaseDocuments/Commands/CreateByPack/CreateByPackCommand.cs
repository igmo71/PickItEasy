using MediatR;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.CreateByPack
{
    public class CreateByPackCommand : IRequest
    {
        public required List<WhsOrderOutBaseDocumentDto> WhsOrderOutBaseDocumentDtos { get; set; }
    }
}
