using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.BaseDocuments
{
    public class BaseDocumentDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
