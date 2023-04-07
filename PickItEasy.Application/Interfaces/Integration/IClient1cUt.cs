using PickItEasy.Application.Dtos;
using System.Net;

namespace PickItEasy.Application.Interfaces.Integration
{
    public interface IClient1cUt : IIntegrationClient
    {
        Task<string> PostWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto);
    }
}
