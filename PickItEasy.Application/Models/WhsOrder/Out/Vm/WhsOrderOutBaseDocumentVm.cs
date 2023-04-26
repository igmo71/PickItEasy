namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutBaseDocumentVm
    {
        public required Guid BaseDocumentId { get; set; }
        public required string Name { get; set; }
    }
}
