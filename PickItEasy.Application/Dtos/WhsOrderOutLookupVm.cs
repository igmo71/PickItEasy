using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutLookupVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }

        public WhsOrderOutStatusVm? Status { get; set; }
        public WhsOrderOutQueueVm? Queue { get; set; }
    }
}
