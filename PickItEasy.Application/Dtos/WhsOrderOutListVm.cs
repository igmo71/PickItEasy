namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutListVm
    {
        public List<WhsOrderOutLookupVm> Orders { get; set; } = new();
    }
}