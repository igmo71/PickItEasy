using Mapster;
using PickItEasy.Domain.Entities.WhsOrder.Out;
using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutDto : MappedModel
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

        public string? QueueNumber { get; set; }

        [Required]
        public DateTime ShipDateTime { get; set; }

        public string? Comment { get; set; }

        [Required]
        public List<WhsOrderOutProductDto>? Products { get; set; }

        [Required]
        public List<WhsOrderOutBaseDocumentDto>? BaseDocuments { get; set; }

        //public static void RegisterMapping()
        //{
        //    TypeAdapterConfig<WhsOrderOutDto, WhsOrderOut>
        //        .NewConfig()
        //        .Map(dst => dst.WhsOrderOutBaseDocuments, src => src.BaseDocuments)
        //        .Map(dst => dst.WhsOrderOutProducts, src => src.Products)
        //        .Ignore(dst => dst.StatusId)
        //        .Ignore(dst => dst.Status)
        //        .Ignore(dst => dst.QueueId)
        //        .Ignore(dst => dst.Queue)
        //        .Ignore(dst => dst.Warehouse)
        //        .Ignore(dst => dst.BaseDocuments)
        //        .Ignore(dst => dst.Products)
        //        .RequireDestinationMemberSource(true);
        //}

        public override void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<WhsOrderOutDto, WhsOrderOut>()
                .Map(dst => dst.WhsOrderOutBaseDocuments, src => src.BaseDocuments)
                .Map(dst => dst.WhsOrderOutProducts, src => src.Products)
                .Ignore(dst => dst.StatusId)
                .Ignore(dst => dst.Status)
                .Ignore(dst => dst.QueueId)
                .Ignore(dst => dst.Queue)
                .Ignore(dst => dst.Warehouse)
                .Ignore(dst => dst.BaseDocuments)
                .Ignore(dst => dst.Products)
                .RequireDestinationMemberSource(true);
        }
    }
}