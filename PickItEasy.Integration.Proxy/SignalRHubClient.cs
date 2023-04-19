using Microsoft.AspNetCore.SignalR.Client;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Integration.Proxy
{
    public class SignalRHubClient : ISignalRHubClient
    {
        private readonly HubConnection _hubConnection;
        private readonly ILogger<SignalRHubClient> _logger;

        private readonly IRequestHandler _requestHandler;

        public SignalRHubClient(IConfiguration configuration, ILogger<SignalRHubClient> logger, IRequestHandler requestHandler)
        {
            _logger = logger;

            //string hubUrl = configuration.GetSection("HubUri").Value ?? throw new ApplicationException("Fail to get configuration");
            string hubUrl = configuration.GetValue<string>("HubUri") ?? throw new ApplicationException("Fail to get configuration");

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            StartConnection().GetAwaiter().GetResult();

            _hubConnection.Closed += async (ex) =>
            {
                _logger.LogError(ex, "Disconnected");
                await StartConnection();
            };

            _hubConnection.On("PostWhsOrderOutDto", new[] { typeof(WhsOrderOutDto) }, async (input) =>
            {
                var result = await OnPostWhsOrderOutDto(input);
                return result;
            });

            _requestHandler = requestHandler;

        }

        private async Task StartConnection()
        {
            _logger.LogInformation("Trying to connect");
            try
            {
                await _hubConnection.StartAsync();
                _logger.LogInformation("Connected");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                await Task.Delay(10000);
                await StartConnection();
            }
        }

        public string State => _hubConnection.State.ToString();

        public async Task SendMessageAsync(string message)
        {
            var result = await _hubConnection.InvokeAsync<string>("GetMessage", message);
            await Console.Out.WriteLineAsync(result);
        }

        private async Task<string> OnPostWhsOrderOutDto(object?[] input)
        {
            WhsOrderOutDto whsOrderOutDto = input[0] as WhsOrderOutDto ?? throw new ApplicationException("Input is Empty");
            var result = await _requestHandler.Handle<WhsOrderOutDto>(whsOrderOutDto);
            return result;
        }
    }
}
