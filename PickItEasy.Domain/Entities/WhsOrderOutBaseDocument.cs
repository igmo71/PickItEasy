namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOutBaseDocument : WhsOrderBaseDocument
    {
        public Guid WhsOrderOutId { get; set; }
        public WhsOrderOut? WhsOrderOut { get; set; }
    }
}
