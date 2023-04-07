using Microsoft.AspNetCore.SignalR.Client;
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

        public Hub1cUtClientService(string hubUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();            
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
