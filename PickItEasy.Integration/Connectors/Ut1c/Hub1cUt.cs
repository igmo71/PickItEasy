using Microsoft.AspNetCore.SignalR;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public class Hub1cUt : Hub<IHub1cUtClient>
    {
        private static string connectionId = string.Empty;
        public static string ConnectionId => connectionId;

        public static event EventHandler<string>? MessageReceived;

        public void GetMessage(string message)
        {
            Console.WriteLine(message);
            OnMessageReceived(message);
        }

        private void OnMessageReceived(string content)
        {
            MessageReceived?.Invoke(this, content);
        }

        public override async Task OnConnectedAsync()
        {
            connectionId = Context.ConnectionId;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)        
        {
            connectionId = string.Empty;
            await base.OnDisconnectedAsync(exception);
        }
    }
}
