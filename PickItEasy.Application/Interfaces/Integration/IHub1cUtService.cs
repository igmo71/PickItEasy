using PickItEasy.Application.Dtos;

namespace PickItEasy.Application.Interfaces.Integration
{
    public interface IHub1cUtService
    {
        Task<string> SendWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto);
    }
}
