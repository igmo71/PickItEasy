using Microsoft.AspNetCore.SignalR.Client;
using PickItEasy.Application.Dtos;
using System.Net;
using System.Threading.Channels;

namespace PickItEasy.Integration.Proxy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string HUB_URL = "https://localhost:55927/Hub1cUt";
            Console.WriteLine("Hub Url:");
            var hubUriStr = Console.ReadLine();

            //Uri.TryCreate(hubUriStr, creationOptions: ..., out Uri hubUri);

            var hubConnection = new HubConnectionBuilder()
                .WithUrl(string.IsNullOrEmpty(hubUriStr) ? HUB_URL : hubUriStr)
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

            //while (true) {
            //    var message = string.Empty;
            //    Console.Write("Message: ");
            //    message = Console.ReadLine();

            //    await hubConnection.SendAsync("GetMessage", message);
            //}

            //Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

            static async Task TryStartConnection(HubConnection hubConnection)
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