namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutListVm
    {
        public List<WhsOrderOutLookupVm>? Orders { get; set; }
    }

    public class WhsOrderOutLookupVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }
    }
}