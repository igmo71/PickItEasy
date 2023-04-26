﻿using MediatR;
using PickItEasy.Application.Models.BaseDocuments;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.Create
{
    public class CreateCommand : IRequest<BaseDocumentDto>
    {
        public required BaseDocumentDto BaseDocumentDto { get; set; }
    }
}
