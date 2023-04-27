using System;
using System.ComponentModel.DataAnnotations;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Models.BaseDocuments;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutBaseDocumentDto
    {
        [Required]
        public Guid DocumentId { get; set; }

        [Required]
        public string? DocumentName { get; set; }

        public static void RegisterMapping()
        {
            TypeAdapterConfig<WhsOrderOutBaseDocumentDto, BaseDocumentDto>
                .NewConfig()
                .Map(dst => dst.Id, src => src.DocumentId)
                .Map(dst => dst.Name, src => src.DocumentName)
                .RequireDestinationMemberSource(true);
        }
    }

    public static class WhsOrderOutBaseDocumentDtoMapping
    {
        public static void Register()
        {
            TypeAdapterConfig<WhsOrderOutBaseDocumentDto, BaseDocumentDto>
                .NewConfig()
                .Map(dst => dst.Id, src => src.DocumentId)
                .Map(dst => dst.Name, src => src.DocumentName)
                .RequireDestinationMemberSource(true);
        }

    }
}
