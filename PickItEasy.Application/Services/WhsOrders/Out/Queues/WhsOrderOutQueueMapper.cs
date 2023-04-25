using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out.Queues
{
    public class WhsOrderOutQueueMapper
    {
        public static WhsOrderOutQueueVm Map(WhsOrderOutQueue source)
        {
            WhsOrderOutQueueVm destination = new WhsOrderOutQueueVm
            {
                Id = source.Id,
                Name = source.Name,
                Synonym = source.Synonym,
                Value = source.Value,
                Active = source.Active
            };

            return destination;
        }

        public static WhsOrderOutQueueListVm Map(List<WhsOrderOutQueue> source)
        {
            WhsOrderOutQueueListVm destination = new()
            {
                Queues = new()
            };

            foreach (var item in source)
            {
                destination.Queues.Add(Map(item));
            }

            return destination;
        }
    }
}