using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.BaseDocuments
{
    public class BaseDocumentDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
