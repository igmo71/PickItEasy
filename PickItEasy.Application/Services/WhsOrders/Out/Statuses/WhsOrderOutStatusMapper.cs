using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out.Statuses
{
    public class WhsOrderOutStatusMapper
    {
        public static WhsOrderOutStatusVm Map(WhsOrderOutStatus source)
        {
            WhsOrderOutStatusVm destination = new WhsOrderOutStatusVm
            {
                Id = source.Id,
                Name = source.Name,
                Synonym = source.Synonym,
                Value = source.Value,
                Active = source.Active
            };

            return destination;
        }

        public static WhsOrderOutStatusListVm Map(List<WhsOrderOutStatus> source)
        {
            WhsOrderOutStatusListVm destination = new()
            {
                Statuses = new()
            };

            foreach (var item in source)
            {
                destination.Statuses.Add(Map(item));
            }

            return destination;
        }
    }
}
