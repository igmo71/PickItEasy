namespace PickItEasy.Integration.Proxy
{
    public interface ISignalRHubClient
    {
        string State { get; }
        Task SendMessageAsync(string message);
    }
}
