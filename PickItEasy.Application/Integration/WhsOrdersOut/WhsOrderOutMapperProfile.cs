using AutoMapper;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class WhsOrderOutMapperProfile : Profile
    {
        public WhsOrderOutMapperProfile()
        {
            CreateMap<WhsOrderOutVm, WhsOrderOutDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(dto => dto.Number, opt => opt.MapFrom(vm => vm.Number))
                .ForMember(dto => dto.DateTime, opt => opt.MapFrom(vm => vm.DateTime))
                .ForMember(dto => dto.Products, opt => opt.MapFrom(vm => vm.Products));

            CreateMap<WhsOrderOutProductVm, WhsOrderOutProductDto>()
                .ForMember(dto => dto.ProductId, opt => opt.MapFrom(vm => vm.ProductId))
                .ForMember(dto => dto.Count, opt => opt.MapFrom(vm => vm.Count));
        }
    }
}
