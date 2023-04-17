using AutoMapper;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class WarehouseMappingProfile : Profile
    {
        public WarehouseMappingProfile()
        {
            CreateMap<WarehouseDto, Warehouse>()
                .ForMember(warehouse => warehouse.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(warehouse => warehouse.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(warehouse => warehouse.IsActive, opt => opt.Ignore());

            CreateMap<Warehouse, WarehouseVm>();
        }
    }
}
