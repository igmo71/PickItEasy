namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutDictionaryByQueueVm
    {
        public Dictionary<Guid, List<WhsOrderOutLookupVm>>? Orders { get; set; }
    }
}
