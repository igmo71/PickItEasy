using PickItEasy.Application.Models.WhsOrder.Out.Dto;

namespace PickItEasy.Application.Interfaces.Integration
{
    public interface IClient1cUt : IIntegrationClient
    {
        Task<string> PostWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto);
    }
}
