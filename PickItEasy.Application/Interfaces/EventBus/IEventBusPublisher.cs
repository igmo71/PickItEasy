namespace PickItEasy.Application.Interfaces.EventBus
{
    public interface IEventBusPublisher
    {
        void SendMessage(object obj);
        void SendMessage(string message);
    }
}
