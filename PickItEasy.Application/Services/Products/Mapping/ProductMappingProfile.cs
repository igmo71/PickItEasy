using AutoMapper;
using PickItEasy.Application.Services.Products.Commands.Create;
using PickItEasy.Application.Services.Products.Queries.GetById;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Products.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Create
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, CreateProductVm>();

            // GetById
            CreateMap<Product, GetByIdProductVm>();
        }
    }
}
