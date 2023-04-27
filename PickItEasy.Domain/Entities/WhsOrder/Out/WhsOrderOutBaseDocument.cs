using PickItEasy.Domain.Entities.WhsOrder;

namespace PickItEasy.Domain.Entities.WhsOrder.Out
{
    public class WhsOrderOutBaseDocument : WhsOrderBaseDocument
    {
        public Guid WhsOrderOutId { get; set; }
        public WhsOrderOut? WhsOrderOut { get; set; }
    }
}
