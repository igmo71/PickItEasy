using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutVm
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }

        public List<GetByIdWhsOrderOutProductVm>? Products { get; set; }
    }

    public class GetByIdWhsOrderOutProductVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public float Count { get; set; }
    }
}