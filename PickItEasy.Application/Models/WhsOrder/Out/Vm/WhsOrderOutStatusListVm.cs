using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutStatusListVm
    {
        public List<WhsOrderOutStatusVm>? Statuses { get; set; }

        /// <summary>
        /// Map from List<WhsOrderOutStatus> to WhsOrderOutStatusListVm
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static WhsOrderOutStatusListVm Map(List<WhsOrderOutStatus> source)
        {
            WhsOrderOutStatusListVm destination = new()
            {
                Statuses = new()
            };

            foreach (var item in source)
            {
                destination.Statuses.Add(WhsOrderOutStatusVm.Map(item));
            }

            return destination;
        }
    }
}
