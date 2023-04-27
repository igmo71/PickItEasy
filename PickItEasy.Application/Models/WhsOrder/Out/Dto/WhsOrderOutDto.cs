using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Number { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public Guid WarehouseId { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int Queue { get; set; }

        [Required]
        public string? QueueNumber { get; set; }

        [Required]
        public DateTime ShipDateTime { get; set; }

        [Required]
        public string? Comment { get; set; }

        [Required]
        public List<WhsOrderOutProductDto>? Products { get; set; }

        [Required]
        public List<WhsOrderOutBaseDocumentDto>? BaseDocuments { get; set; }
    }
}