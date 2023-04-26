namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutDictionaryByQueueVm
    {
        public Dictionary<Guid, List<WhsOrderOutLookupVm>>? Orders { get; set; }
    }
}
