using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutQueueVm
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string? Synonym { get; set; }

        /// <summary>
        /// Map from WhsOrderOutQueue to WhsOrderOutQueueVm
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static WhsOrderOutQueueVm Map(WhsOrderOutQueue source)
        {
            WhsOrderOutQueueVm destination = new WhsOrderOutQueueVm
            {
                Id = source.Id,
                Synonym = source.Synonym,
                Value = source.Value
            };

            return destination;
        }
    }
}
