using AutoMapper;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class WhsOrderOutStatusMappingProfile : Profile
    {
        public WhsOrderOutStatusMappingProfile()
        {
            CreateMap<WhsOrderOutStatus, WhsOrderOutStatusVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(vm => vm.Synonym, opt => opt.MapFrom(s => s.Synonym));
        }
    }
}
