using PickItEasy.Domain.Entities;

namespace PickItEasy.Integration.Connectors.Ut1c.SeedData
{
    public class WhsOrderOutQueueInitial
    {
        private static readonly List<WhsOrderOutQueue> whsOrderOutQueues = new()
        {
            new WhsOrderOutQueue {Id = Guid.Parse("7E83260A-316F-4A1F-BE9A-BF353B118536"), Value = 10, Active = true, Name = "LiveQueue",     Synonym = "Живая очередь"},
            new WhsOrderOutQueue {Id = Guid.Parse("3558D2BA-FFB6-4F08-9891-F7F1E8853C83"), Value = 20, Active = true, Name = "Schedule",      Synonym = "Собрать к дате"},
            new WhsOrderOutQueue {Id = Guid.Parse("D964FCAD-D71D-480A-BDEB-0B2C045FCD90"), Value = 30, Active = true, Name = "SelfDelivery",  Synonym = "Собственная доставка"},
            new WhsOrderOutQueue {Id = Guid.Parse("8BDC656E-8A2C-4AEF-9422-E0A419608190"), Value = 40, Active = true, Name = "NoQue",         Synonym = "Очередность не указана"},
        };

        public static List<WhsOrderOutQueue> List => whsOrderOutQueues;
    }
}
