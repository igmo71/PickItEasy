namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutDictionaryByQueueVm
    {
        public Dictionary<Guid, List<WhsOrderOutLookupVm>>? Orders { get; set; }
    }
}
