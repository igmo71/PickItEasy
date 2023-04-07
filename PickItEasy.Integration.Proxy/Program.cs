using Microsoft.AspNetCore.SignalR.Client;
using PickItEasy.Application.Dtos;
using Serilog;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PickItEasy.Integration.Proxy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<ProxyWorker>();
            builder.Services.AddHostedService<HealthChecker>();

            string hubUri = "https://localhost:55927/Hub1cUt";
            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUri)
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<WhsOrderOutDto>("PostWhsOrderOutDto", async (dto) =>
            {
                await PostWhsOrderOutDto(dto, hubConnection);
            });

            hubConnection.On("PostWhsOrderOutDtoWithResponse", new[] { typeof(WhsOrderOutDto) }, HandleWhsOrderOutDtoRequest);

            await TryStartConnection(hubConnection);

            builder.Services.AddHostedService<ProxyWorker>();
            builder.Services.AddHostedService<HealthChecker>();
            IHost host = builder.Build();
            host.Run();
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

        private static Task<string> PostWhsOrderOutDtoWithResponse(WhsOrderOutDto dto)
        {
            Log.Information($"{dto.Name}");
            var httpStatusCode = HttpStatusCode.OK;
            return Task.FromResult($"{dto.Name} - {httpStatusCode}"); // Guid
        }
        public static async Task<string> HandleWhsOrderOutDtoRequest(object?[] input)
        {
            Console.WriteLine($"{(input[0] as WhsOrderOutDto).Name} - received");

            // Do some asynchronous work
            await Task.Delay(1000);

            var result = (input[0] as WhsOrderOutDto).Name;
            return $"{result} - Ok";
        }

    }
}