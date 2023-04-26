namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutBaseDocumentDto
    {
        public required Guid DocumentId { get; set; }
        public required string DocumentName { get; set; }
    }
}
