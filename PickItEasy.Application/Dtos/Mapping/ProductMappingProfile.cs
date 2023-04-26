using AutoMapper;
using PickItEasy.Application.Models.Products;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(product => product.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(product => product.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(product => product.Active, opt => opt.MapFrom(dto => dto.Active));

            CreateMap<Product, ProductVm>();
        }
    }
}
