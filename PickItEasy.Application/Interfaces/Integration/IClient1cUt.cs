using PickItEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Interfaces.Integration
{
    public interface IClient1cUt : IIntegrationClient
    {
        Task<HttpStatusCode> PostWhsOrderOutAsync(WhsOrderOut whsOrder);
    }
}
