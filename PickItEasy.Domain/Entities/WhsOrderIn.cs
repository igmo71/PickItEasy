namespace PickItEasy.Domain.Entities
{
    public class WhsOrderIn : WhsOrder
    {
        public List<WhsOrderInProduct>? WhsOrderInProducts { get; set; }
    }
}
