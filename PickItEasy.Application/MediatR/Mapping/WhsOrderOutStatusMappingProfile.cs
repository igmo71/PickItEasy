using AutoMapper;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Application.MediatR.Mapping
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
