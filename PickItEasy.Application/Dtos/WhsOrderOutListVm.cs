namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutListVm
    {
        public Dictionary<Guid, List<WhsOrderOutLookupVm>>? Orders { get; set; }
        public Dictionary<Guid, int>? CountByStatus { get; set; }
    }
}