namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList
{
    public class GetListWhsOrderOutVm
    {
        public List<GetListWhsOrderOutLookup>? Orders { get; set; }
    }

    public class GetListWhsOrderOutLookup
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }
    }
}