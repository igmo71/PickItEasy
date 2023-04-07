using Microsoft.AspNetCore.SignalR.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Integration.Proxy
{
    public class Hub1cUtClientService : ISignalRHubClient
    {

        private readonly HubConnection _hubConnection;
        private readonly ILogger<Hub1cUtClientService> _logger;

        public Hub1cUtClientService(IConfiguration configuration, ILogger<Hub1cUtClientService> logger)
        {
            _logger = logger;
            string hubUrl = configuration.GetSection("HubUrl").Value
                ?? throw new ApplicationException("Fail to get configuration");
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
        }

        private async Task StartConnection()
        {
            _logger.LogInformation($"Trying to connect");
            try
            {
                await _hubConnection.StartAsync();
                _logger.LogInformation($"Connected");
            }
            catch (Exception ex)
            {
                await Task.Delay(10000);
                await StartConnection();
            }
        }

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
    }
}
