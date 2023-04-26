using PickItEasy.Application.Models.WhsOrder.Out.Dto;

namespace PickItEasy.Application.Interfaces.Integration
{
    public interface IHub1cUtService
    {
        Task<string> SendWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto);
    }
}
