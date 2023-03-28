﻿using AutoMapper;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Application.Services.WhsOrdersOut.Dto;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Mapping
{
    public class WhsOrderOutMapperProfile : Profile
    {
        public WhsOrderOutMapperProfile()
        {
            CreateMap<CreateWhsOrderOutDto, WhsOrderOut>()
                .ForMember(order => order.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(order => order.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(order => order.Number, opt => opt.MapFrom(dto => dto.Number))
                .ForMember(order => order.DateTime, opt => opt.MapFrom(dto => dto.DateTime))
                .ForMember(order => order.WhsOrderOutProducts, opt => opt.MapFrom(dto => dto.Products))
                .ForMember(order => order.Products, opt => opt.Ignore());

            CreateMap<CreateWhsOrderOutProductDto,  WhsOrderOutProduct>()
                .ForMember(product => product.ProductId, opt => opt.MapFrom(dto => dto.ProductId))
                .ForMember(product => product.Count, opt => opt.MapFrom(dto => dto.Count))
                .ForMember(product => product.Product, opt => opt.Ignore())
                .ForMember(product => product.WhsOrderOut, opt => opt.Ignore());

            CreateMap<WhsOrderOut, WhsOrderOutVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(order => order.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(order => order.Name))
                .ForMember(vm => vm.Number, opt => opt.MapFrom(order => order.Number))
                .ForMember(vm => vm.DateTime, opt => opt.MapFrom(order => order.DateTime))
                .ForMember(vm => vm.Products, opt => opt.MapFrom(order => order.WhsOrderOutProducts));

            CreateMap<WhsOrderOutProduct, WhsOrderOutProductVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(product => product.Id))                
                .ForMember(vm => vm.Count, opt => opt.MapFrom(product => product.Count));
        }
    }
}
