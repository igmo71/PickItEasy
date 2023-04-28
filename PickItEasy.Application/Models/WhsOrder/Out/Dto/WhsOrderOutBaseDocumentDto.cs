using Mapster;
using PickItEasy.Application.Models.BaseDocuments;
using PickItEasy.Domain.Entities.WhsOrder.Out;
using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutBaseDocumentDto : MappedModel
    {
        [Required]
        public Guid DocumentId { get; set; }

        [Required]
        public string? DocumentName { get; set; }


        //public static void RegisterMapping()
        //{
        //    TypeAdapterConfig<WhsOrderOutBaseDocumentDto, BaseDocumentDto>
        //        .NewConfig()
        //        .Map(dst => dst.Id, src => src.DocumentId)
        //        .Map(dst => dst.Name, src => src.DocumentName)
        //        .RequireDestinationMemberSource(true);

        //    TypeAdapterConfig<WhsOrderOutBaseDocumentDto, WhsOrderOutBaseDocument>
        //        .NewConfig()
        //        .Map(dst => dst.BaseDocumentId, src => src.DocumentId)
        //        .Ignore(dst => dst.BaseDocument)
        //        .Ignore(dst => dst.WhsOrderOutId)
        //        .Ignore(dst => dst.WhsOrderOut)
        //        .Ignore(dst => dst.Id)
        //        .RequireDestinationMemberSource(true);
        //}

        public override void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WhsOrderOutBaseDocumentDto, BaseDocumentDto>()
                .RequireDestinationMemberSource(true)
                .Map(dst => dst.Id, src => src.DocumentId)
                .Map(dst => dst.Name, src => src.DocumentName);

            config.NewConfig<WhsOrderOutBaseDocumentDto, WhsOrderOutBaseDocument>()
                .RequireDestinationMemberSource(true)
                .Map(dst => dst.BaseDocumentId, src => src.DocumentId)
                .Ignore(dst => dst.BaseDocument)
                .Ignore(dst => dst.WhsOrderOutId)
                .Ignore(dst => dst.WhsOrderOut)
                .Ignore(dst => dst.Id);
        }
    }
}
