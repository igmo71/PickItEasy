using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public class WhsOrderOutStatus
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public required string Name { get; set; }
        public required string Synonym { get; set; }
        public bool IsAtive { get; set; }

        private static readonly List<WhsOrderOutStatus> whsOrderOutStatuses = new() // TODO: кастыль 
        {
            new WhsOrderOutStatus { Id = Guid.Parse("C2C5935D-B332-4D84-B1FD-309AD8A65356"), Value = 0, Name = "Подготовлено", Synonym = "Подготовлено", IsAtive = true},
            new WhsOrderOutStatus { Id = Guid.Parse("E1A4C395-F7A3-40AF-82AB-AD545E51ECA7"), Value = 1, Name = "КОтбору", Synonym = "К отбору", IsAtive = true},
            new WhsOrderOutStatus { Id = Guid.Parse("BD1AE241-D787-4A6D-B920-029BC6577364"), Value = 2, Name = "КПроверке", Synonym = "К проверке", IsAtive = false},
            new WhsOrderOutStatus { Id = Guid.Parse("17CEE206-E06F-47D8-824D-14EECEAF394A"), Value = 3, Name = "ВПроцессеПроверки", Synonym = "В процессе проверки", IsAtive = false},
            new WhsOrderOutStatus { Id = Guid.Parse("E911589B-613C-42AD-AD56-7083C481C4B4"), Value = 4, Name = "Проверен", Synonym = "Проверен", IsAtive = false},
            new WhsOrderOutStatus { Id = Guid.Parse("7C2BD6BE-CF81-4B1A-9ACF-D4EBF416F4D3"), Value = 5, Name = "КОтгрузке", Synonym = "К отгрузке", IsAtive = true},
            new WhsOrderOutStatus { Id = Guid.Parse("63E9D44C-DD4F-4D87-8C70-E97A96EAA989"), Value = 6, Name = "Отгружен", Synonym = "Отгружен", IsAtive = true}
        };
        public static List<WhsOrderOutStatus> List => whsOrderOutStatuses;

        public static bool Contains(int status)
        {
            return status >= whsOrderOutStatuses.MinBy(l => l.Value)?.Value && status <= whsOrderOutStatuses.MaxBy(l => l.Value)?.Value;
        }
    }
}
