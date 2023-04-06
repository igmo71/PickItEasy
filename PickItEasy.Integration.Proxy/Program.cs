using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Dtos;
using System.Net;
using System.Threading.Channels;
using Microsoft.Extensions.Hosting;

namespace PickItEasy.Integration.Proxy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);


            string hubUriParam = builder.Configuration.GetSection("hubUri").Value
                ?? throw new ApplicationException("Fail to get configuration");
            
            var uriCreationOptions = new UriCreationOptions { DangerousDisablePathAndQueryCanonicalization = true };
            if (!Uri.TryCreate(hubUriParam, uriCreationOptions, out Uri? hubUri))
                throw new ApplicationException("Fail to create Hub Uri");


            var hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUri)
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<string>("ReceiveMessage", HandleResievedMessage);
            
            hubConnection.On<WhsOrderOutDto>("PostWhsOrderOutDto", async (dto) =>
            {
                await PostWhsOrderOutDto(dto, hubConnection);
            });
            
            hubConnection.Closed += async (ex) =>
            {
                Console.WriteLine($"Disconnected at {DateTime.Now}");
                await TryStartConnection(hubConnection);
            };

            await TryStartConnection(hubConnection);

            using IHost host = builder.Build();
            await host.StartAsync();

            
        }
        private static async Task TryStartConnection(HubConnection hubConnection)
        {
            await Console.Out.WriteLineAsync($"Trying to connect at {DateTime.Now}");
            try
            {
                await hubConnection.StartAsync();
                Console.WriteLine($"Connected at {DateTime.Now}");
            }
            catch (Exception)
            {
                await Task.Delay(3000);
                await TryStartConnection(hubConnection);
            }
        }

        private static async Task PostWhsOrderOutDto(WhsOrderOutDto dto, HubConnection hubConnection)
        {
            Console.WriteLine($"{dto.Name}");
            var httpStatusCode = HttpStatusCode.OK;
            await hubConnection.SendAsync("GetResult", $"{dto.Name} - {httpStatusCode}"); // Guid
        }

        private static void HandleResievedMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}