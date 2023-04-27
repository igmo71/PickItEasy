using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Integration.Connectors.Ut1c.SeedData
{
    public class WhsOrderOutStatusInitial
    {
        private static readonly List<WhsOrderOutStatus> whsOrderOutStatuses = new() // TODO: кастыль 
        {
            new WhsOrderOutStatus { Id = Guid.Parse("C2C5935D-B332-4D84-B1FD-309AD8A65356"), Value = 0, Active = true,  Name = "Подготовлено",        Synonym = "Подготовлено"},
            new WhsOrderOutStatus { Id = Guid.Parse("E1A4C395-F7A3-40AF-82AB-AD545E51ECA7"), Value = 1, Active = true,  Name = "КОтбору",             Synonym = "К отбору"},
            new WhsOrderOutStatus { Id = Guid.Parse("BD1AE241-D787-4A6D-B920-029BC6577364"), Value = 2, Active = false, Name = "КПроверке",           Synonym = "К проверке"},
            new WhsOrderOutStatus { Id = Guid.Parse("17CEE206-E06F-47D8-824D-14EECEAF394A"), Value = 3, Active = false, Name = "ВПроцессеПроверки",   Synonym = "В процессе проверки"},
            new WhsOrderOutStatus { Id = Guid.Parse("E911589B-613C-42AD-AD56-7083C481C4B4"), Value = 4, Active = false, Name = "Проверен",            Synonym = "Проверен"},
            new WhsOrderOutStatus { Id = Guid.Parse("7C2BD6BE-CF81-4B1A-9ACF-D4EBF416F4D3"), Value = 5, Active = true,  Name = "КОтгрузке",           Synonym = "К отгрузке"},
            new WhsOrderOutStatus { Id = Guid.Parse("9EBA20CE-9245-4109-92CB-A9875801FBB4"), Value = 6, Active = true,  Name = "Отгружен",            Synonym = "Отгружен"}
        };
        public static List<WhsOrderOutStatus> List => whsOrderOutStatuses;
    }
}
