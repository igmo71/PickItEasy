using AutoMapper;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class WhsOrderOutQueueMappingProfile : Profile
    {
        public WhsOrderOutQueueMappingProfile()
        {
            CreateMap<WhsOrderOutQueue, WhsOrderOutQueueVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(q => q.Id))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(q => q.Value))
                .ForMember(vm => vm.Synonym, opt => opt.MapFrom(q => q.Synonym));
        }
    }
}
