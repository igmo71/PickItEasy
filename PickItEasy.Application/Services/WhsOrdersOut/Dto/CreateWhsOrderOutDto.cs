using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Dto
{
    public class CreateWhsOrderOutDto
    {
        public DateTime DateTime { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }

        public List<CreateWhsOrderOutProductDto>? Products { get; set; }
    }

    public class CreateWhsOrderOutProductDto {
        public Guid ProductId { get; set; }
        public float Count { get; set; }
    }
}