using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutStatusVm
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string? Synonym { get; set; }
    }
}
