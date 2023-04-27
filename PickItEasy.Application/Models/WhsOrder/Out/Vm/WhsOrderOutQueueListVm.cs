using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutQueueListVm
    {
        public List<WhsOrderOutQueueVm>? Queues { get; set; }

        /// <summary>
        /// Map from List<WhsOrderOutQueue> to WhsOrderOutQueueListVm
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static WhsOrderOutQueueListVm Map(List<WhsOrderOutQueue> source)
        {
            WhsOrderOutQueueListVm destination = new()
            {
                Queues = new()
            };

            foreach (var item in source)
            {
                destination.Queues.Add(WhsOrderOutQueueVm.Map(item));
            }

            return destination;
        }
    }
}
