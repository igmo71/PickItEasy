using AutoMapper;
using PickItEasy.Application.Services.Products.Commands.Create;
using PickItEasy.Application.Services.Products.Queries.GetById;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
