namespace PickItEasy.Integration.Connectors.Ut1c
{
    public interface IHub1cUtClient
    {
        Task ReceiveMessage(string message);
        Task<string> ReceiveMessageWithResponse(string message);
    }
}