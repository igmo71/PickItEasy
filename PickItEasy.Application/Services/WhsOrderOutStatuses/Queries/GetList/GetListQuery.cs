﻿using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.GetList
{
    public class GetListQuery : IRequest<WhsOrderOutStatusListVm>
    {
    }
}
