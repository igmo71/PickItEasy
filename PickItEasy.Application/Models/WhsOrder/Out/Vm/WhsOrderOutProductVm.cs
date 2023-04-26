namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutProductVm
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public float Count { get; set; }
    }
}
