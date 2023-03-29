using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutDto
    {
        public required Guid Id { get; set; }   
        public required string Name { get; set; }
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }

        public required List<CreateWhsOrderOutProductDto> Products { get; set; }
    }

    public class CreateWhsOrderOutProductDto
    {
        public Guid ProductId { get; set; }
        public float Count { get; set; }
    }
}