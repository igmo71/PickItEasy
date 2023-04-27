namespace PickItEasy.Domain.Entities.WhsOrder.In
{
    public class WhsOrderIn : WhsOrder
    {
        public List<WhsOrderInProduct>? WhsOrderInProducts { get; set; }
    }
}
