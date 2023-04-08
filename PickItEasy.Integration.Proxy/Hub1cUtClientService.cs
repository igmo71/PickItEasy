using Microsoft.AspNetCore.SignalR.Client;
using PickItEasy.Application.Dtos;

namespace PickItEasy.Integration.Proxy
{
    public delegate Task<string> OnPostWhsOrderOutDtoHandler(WhsOrderOutDto dto);
    public class Hub1cUtClientService : ISignalRHubClient
    {
        private readonly HubConnection _hubConnection;
        private readonly ILogger<Hub1cUtClientService> _logger;
        public static OnPostWhsOrderOutDtoHandler? postWhsOrderOutDtoHandler;

        private readonly IRequestHandler _requestHandler;

        public Hub1cUtClientService(IConfiguration configuration, ILogger<Hub1cUtClientService> logger, IRequestHandler requestHandler)
        {
            _logger = logger;

            //string hubUrl = configuration.GetSection("HubUri").Value ?? throw new ApplicationException("Fail to get configuration")
            string hubUrl = configuration.GetValue<string>("HubUri") ?? throw new ApplicationException("Fail to get configuration"); ;

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
                var result = await OnPostWhsOrderOutDto((input[0] as WhsOrderOutDto));
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
                await Task.Delay(10000);
                await StartConnection();
            }
        }

        public string State => _hubConnection.State.ToString();

        public async Task Connect()
        {
            await _hubConnection.StartAsync();
        }

        public async Task Disconnect()
        {
            await _hubConnection.StopAsync();
        }

        public async Task SendMessage(string message)
        {
            var result = await _hubConnection.InvokeAsync<string>("SendMessage", message);
        }

        public static void RegisterPostWhsOrderOutDtoHandler(OnPostWhsOrderOutDtoHandler handler)
        {
            postWhsOrderOutDtoHandler += handler;
        }

        public static void UnregisterPostWhsOrderOutDtoHandler(OnPostWhsOrderOutDtoHandler handler)
        {
            postWhsOrderOutDtoHandler -= handler;
        }

        private async Task<string> OnPostWhsOrderOutDto(WhsOrderOutDto? whsOrderOutDto)
        {
            var result = await postWhsOrderOutDtoHandler?.Invoke(whsOrderOutDto); // TODO: Check whsOrderOutDto!
            return result;
        }
    }
}
