using PickItEasy.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }

        public required bool Active { get; set; }

        public required Guid WarehouseId { get; set; }

        public required int Status { get; set; }

        public required int Queue { get; set; }
        public required string QueueNumber { get; set; }

        public DateTime ShipDateTime { get; set; }

        public string? Comment { get; set; }

        public required List<WhsOrderOutProductDto> Products { get; set; }
        public required List<WhsOrderOutBaseDocumentDto> BaseDocuments { get; set; }


        public static WhsOrderOut Map(WhsOrderOutDto source)
        {
            WhsOrderOut destination = new()
            {
                Id = source.Id,
                Name = source.Name,
                Number = source.Number,
                DateTime = source.DateTime,
                Active = source.Active,
                Comment = source.Comment,
                WarehouseId = source.WarehouseId,
                QueueNumber = source.QueueNumber,
                ShipDateTime = source.ShipDateTime
            };

            foreach (var item in source.Products)
            {
                destination.WhsOrderOutProducts.Add(WhsOrderOutProductDto.Map(item));
            }

            foreach (var item in source.BaseDocuments)
            {
                destination.WhsOrderOutBaseDocuments.Add(WhsOrderOutBaseDocumentDto.Map(item));
            }

            return destination;
        }
    }
}