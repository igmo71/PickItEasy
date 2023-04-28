using Mapster;
using PickItEasy.Application.Interfaces.Integration;
using PickItEasy.Application.Interfaces.Integration.WhsOrder.Out;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Integration.WhsOrder.Out
{
    public class WhsOrderOutService : IWhsOrderOutService
    {
        private bool isUseProxy = true;
        private readonly IClient1cUt _client1CUt;
        private readonly IHub1cUtService _hub1cUtService;

        public WhsOrderOutService(IClient1cUt client1CUt, IHub1cUtService hub1cUtService)
        {
            _client1CUt = client1CUt;
            _hub1cUtService = hub1cUtService;
        }

        public async Task<string> PostOrder(WhsOrderOutVm whsOrderOutVm)
        {
            WhsOrderOutDto whsOrderOutDto = whsOrderOutVm.Adapt<WhsOrderOutDto>();

            string result = "error";

            if (isUseProxy)
                result = await _hub1cUtService.SendWhsOrderOutAsync(whsOrderOutDto);
            else
                result = await _client1CUt.PostWhsOrderOutAsync(whsOrderOutDto);

            return result;
        }
    }
}
