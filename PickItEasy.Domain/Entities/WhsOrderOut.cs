namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOut : WhsOrder
    {
        public List<WhsOrderOutProduct> WhsOrderOutProducts { get; set; } = new();
    }
}
