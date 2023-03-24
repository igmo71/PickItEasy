using AutoMapper;
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
            CreateMap<CreateWhsOrderOutDto, WhsOrderOut>();
            CreateMap<CreateWhsOrderOutProductDto,  WhsOrderOutProduct>();
            CreateMap<WhsOrderOut, WhsOrderOutVm>();
        }
    }
}
