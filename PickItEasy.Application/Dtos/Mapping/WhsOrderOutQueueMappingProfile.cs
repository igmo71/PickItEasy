using AutoMapper;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;
using PickItEasy.Domain.Entities.WhsOrder.Out;

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
