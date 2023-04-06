using Microsoft.AspNetCore.SignalR;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public class Hub1cUt : Hub<IHub1cUtClient>
    {
        public const string HUB_1C_UT_GROUP = "Hub1cUtGroup";
        private List<string> connections = new List<string>();

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

        public async Task BroadcastMessage(string message)
        {
            await Clients.All.ReceiveMessage(message);
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

        private void OnResultReceived(string content)
        {
            ResultReceived?.Invoke(this, content);
        }

        //private string GetMessage(string originalMessage)
        //{
        //    return $"User connection id: {Context.ConnectionId}. Message: {originalMessage}";
        //}
    }
}
