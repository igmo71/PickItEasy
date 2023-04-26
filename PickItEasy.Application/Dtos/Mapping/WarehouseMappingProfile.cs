using AutoMapper;
using PickItEasy.Application.Models.Warehouse;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class WarehouseMappingProfile : Profile
    {
        public WarehouseMappingProfile()
        {
            CreateMap<WarehouseDto, Warehouse>()
                .ForMember(warehouse => warehouse.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(warehouse => warehouse.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(warehouse => warehouse.Active, opt => opt.MapFrom(dto => dto.Active));

            CreateMap<Warehouse, WarehouseVm>();
        }
    }
}
