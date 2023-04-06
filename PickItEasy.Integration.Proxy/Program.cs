using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using PickItEasy.Application.Dtos;
using Serilog;
using System.Net;

namespace PickItEasy.Integration.Proxy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
                .CreateLogger();

            string hubUriParam = builder.Configuration.GetSection("hubUri").Value
                ?? throw new ApplicationException("Fail to get configuration");
            
            var uriCreationOptions = new UriCreationOptions { DangerousDisablePathAndQueryCanonicalization = true };
            if (!Uri.TryCreate(hubUriParam, uriCreationOptions, out Uri? hubUri))
                throw new ApplicationException("Fail to create Hub Uri");


            var hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUriParam)
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<string>("ReceiveMessage", HandleResievedMessage);
            
            hubConnection.On<WhsOrderOutDto>("PostWhsOrderOutDto", async (dto) =>
            {
                await PostWhsOrderOutDto(dto, hubConnection);
            });
            
            hubConnection.Closed += async (ex) =>
            {
                Log.Information($"Disconnected");
                await TryStartConnection(hubConnection);
            };

            await TryStartConnection(hubConnection);

            using IHost host = builder.Build();
            Console.Read();
            await host.StartAsync();

            
        }
        private static async Task TryStartConnection(HubConnection hubConnection)
        {
            Log.Information($"Trying to connect");
            try
            {
                await hubConnection.StartAsync();
                Log.Information($"Connected");
            }
            catch (Exception ex)
            {
                await Task.Delay(3000);
                await TryStartConnection(hubConnection);
            }
        }

        private static async Task PostWhsOrderOutDto(WhsOrderOutDto dto, HubConnection hubConnection)
        {
            Log.Information($"{dto.Name}");
            var httpStatusCode = HttpStatusCode.OK;
            await hubConnection.SendAsync("GetResult", $"{dto.Name} - {httpStatusCode}"); // Guid
        }

        private static void HandleResievedMessage(string message)
        {
            Log.Information($"{message}");
        }
    }
}