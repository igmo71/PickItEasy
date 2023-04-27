using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutBaseDocumentDto
    {
        [Required]
        public Guid DocumentId { get; set; }

        [Required]
        public string? DocumentName { get; set; }
    }
}
