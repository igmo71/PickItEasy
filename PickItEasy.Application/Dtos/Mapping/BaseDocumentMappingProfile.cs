using AutoMapper;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class BaseDocumentMappingProfile : Profile
    {
        public BaseDocumentMappingProfile()
        {
            CreateMap<BaseDocumentDto, BaseDocument>()
                .ForMember(baseDocument => baseDocument.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(baseDocument => baseDocument.Name, opt => opt.MapFrom(dto => dto.Name));

            CreateMap<WhsOrderOutBaseDocumentDto,BaseDocumentDto>()
                .ForMember(baseDocument => baseDocument.Id, opt => opt.MapFrom(dto => dto.BaseDocumentId))
                .ForMember(baseDocument => baseDocument.Name, opt => opt.MapFrom(dto => dto.Name));

            CreateMap<BaseDocument, BaseDocumentVm>();
        }
    }
}
