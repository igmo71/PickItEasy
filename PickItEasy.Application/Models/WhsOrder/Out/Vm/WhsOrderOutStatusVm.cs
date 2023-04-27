using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutStatusVm
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string? Synonym { get; set; }

        /// <summary>
        /// Map from WhsOrderOutStatus to WhsOrderOutStatusVm
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static WhsOrderOutStatusVm Map(WhsOrderOutStatus source)
        {
            WhsOrderOutStatusVm destination = new WhsOrderOutStatusVm
            {
                Id = source.Id,
                Synonym = source.Synonym,
                Value = source.Value
            };

            return destination;
        }
    }
}
