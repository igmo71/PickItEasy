using AutoMapper;
using PickItEasy.Application.Dtos;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrdersOut.Mapping
{
    public class WhsOrderOutMapperProfile : Profile
    {
        public WhsOrderOutMapperProfile()
        {
            // WhsOrderOutDto => WhsOrderOut
            CreateMap<WhsOrderOutDto, WhsOrderOut>()
                .ForMember(order => order.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(order => order.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(order => order.Number, opt => opt.MapFrom(dto => dto.Number))
                .ForMember(order => order.DateTime, opt => opt.MapFrom(dto => dto.DateTime))
                .ForMember(order => order.WhsOrderOutProducts, opt => opt.MapFrom(dto => dto.Products))
                .ForMember(order => order.Products, opt => opt.Ignore());

            CreateMap<WhsOrderOutProductDto, WhsOrderOutProduct>()
                .ForMember(product => product.ProductId, opt => opt.MapFrom(dto => dto.ProductId))
                .ForMember(product => product.Count, opt => opt.MapFrom(dto => dto.Count))
                .ForMember(product => product.Product, opt => opt.Ignore())
                .ForMember(product => product.WhsOrderOut, opt => opt.Ignore());

            // WhsOrderOut => WhsOrderOutVm
            CreateMap<WhsOrderOut, WhsOrderOutVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(order => order.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(order => order.Name))
                .ForMember(vm => vm.Number, opt => opt.MapFrom(order => order.Number))
                .ForMember(vm => vm.DateTime, opt => opt.MapFrom(order => order.DateTime))
                .ForMember(vm => vm.Products, opt => opt.MapFrom(order => order.WhsOrderOutProducts));

            CreateMap<WhsOrderOutProduct, WhsOrderOutProductVm>()
                .ForMember(vm => vm.ProductId, opt => opt.MapFrom(orderProduct => orderProduct.Id))
                .ForMember(vm => vm.Count, opt => opt.MapFrom(orderProduct => orderProduct.Count))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(orderProduct =>
                    orderProduct.Product == null ? string.Empty : orderProduct.Product.Name));

            // WhsOrderOutVm => WhsOrderOutDto
            CreateMap<WhsOrderOutVm, WhsOrderOutDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(dto => dto.Number, opt => opt.MapFrom(vm => vm.Number))
                .ForMember(dto => dto.DateTime, opt => opt.MapFrom(vm => vm.DateTime))
                .ForMember(dto => dto.Products, opt => opt.MapFrom(vm => vm.Products));

            CreateMap<WhsOrderOutProductVm, WhsOrderOutProductDto>()
                .ForMember(dto => dto.ProductId, opt => opt.MapFrom(vm => vm.ProductId))
                .ForMember(dto => dto.Count, opt => opt.MapFrom(vm => vm.Count));

            // WhsOrderOut => WhsOrderOutLookupVm
            CreateMap<WhsOrderOut, WhsOrderOutLookupVm>()
                .ForMember(lookup => lookup.Id, opt => opt.MapFrom(order => order.Id))
                .ForMember(lookup => lookup.Name, opt => opt.MapFrom(order => order.Name))
                .ForMember(lookup => lookup.Number, opt => opt.MapFrom(order => order.Number))
                .ForMember(lookup => lookup.DateTime, opt => opt.MapFrom(order => order.DateTime));
        }
    }
}
