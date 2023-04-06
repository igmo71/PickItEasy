using Microsoft.AspNetCore.SignalR.Client;

namespace PickItEasy.Integration.Proxy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hub Url:");
            var hubUriStr = Console.ReadLine();
            
            //Uri.TryCreate(hubUriStr, creationOptions: ..., out Uri hubUri);
            
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUriStr)
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<string>("ReceiveMessage", HandleResievedMessage);

            await hubConnection.StartAsync();

            while (true) {
                var message = string.Empty;
                Console.Write("Message: ");
                message = Console.ReadLine();

                await hubConnection.SendAsync("GetMessage", message);
            }
        }

        private static void HandleResievedMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}