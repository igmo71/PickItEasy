using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces.Integration;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public class Hub1cUtService : IHub1cUtService, IDisposable
    {
        private readonly IHubContext<Hub1cUt> _hubContext;
        private readonly ILogger<Hub1cUtService> _logger;

        public Hub1cUtService(IHubContext<Hub1cUt> hubContext, ILogger<Hub1cUtService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
            Hub1cUt.MessageReceived += MessageReceivedHandle;
        }

        private void MessageReceivedHandle(object? sender, string message)
        {
            _logger.LogInformation($"Received: {message}");
        }

        public async Task<string> SendWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto)
        {                                    
            string result = await _hubContext.Clients.Client(Hub1cUt.ConnectionId)
                .InvokeAsync<string>("PostWhsOrderOutDto", whsOrderOutDto, CancellationToken.None);

            _logger.LogInformation("SendWhsOrderOutAsync: {result}", result);
            return result;
        }

        public void Dispose()
        {
            Hub1cUt.MessageReceived -= MessageReceivedHandle;
        }
    }
}
