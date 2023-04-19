using AutoMapper;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class BaseDocumentMappingProfile : Profile
    {
        public BaseDocumentMappingProfile()
        {
            CreateMap<BaseDocumentDto, BaseDocument>()
                .ForMember(baseDocument => baseDocument.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(baseDocument => baseDocument.Name, opt => opt.MapFrom(dto => dto.Name));

            CreateMap<BaseDocument, BaseDocumentVm>();
        }
    }
}
