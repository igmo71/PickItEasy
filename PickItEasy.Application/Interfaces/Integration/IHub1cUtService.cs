using PickItEasy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Interfaces.Integration
{
    public interface IHub1cUtService
    {
        Task<string> SendWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto);
    }
}
