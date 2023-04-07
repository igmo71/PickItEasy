using Microsoft.AspNetCore.SignalR;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public class Hub1cUt : Hub<IHub1cUtClient>
    {
        public const string HUB_1C_UT_GROUP = "Hub1cUtGroup";
        public static List<string> connections = new List<string>();

        public static event EventHandler<string>? ResultReceived;

        public void GetMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void GetResult(string message)
        {
            //Console.WriteLine(message);
            OnResultReceived(message);
        }
        private void OnResultReceived(string content)
        {
            ResultReceived?.Invoke(this, content);
        }

        public async Task BroadcastMessage(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public async Task BroadcastMessageWithResponse(string message)
        {
            var result = await Clients.All.ReceiveMessageWithResponse(message);
            await Console.Out.WriteLineAsync(result);
        }

        public async Task SendToCaller(string message)
        {
            await Clients.Caller.ReceiveMessage("OK");
        }

        public async Task SendToIndividual(string connectionId, string message)
        {
            await Clients.Client(connectionId).ReceiveMessage(message);
        }

        public override async Task OnConnectedAsync()
        {
            connections.Add(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, HUB_1C_UT_GROUP);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)        
        {
            connections.Remove(Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, HUB_1C_UT_GROUP);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
