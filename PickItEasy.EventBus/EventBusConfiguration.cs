using PickItEasy.EventBus.RabbitMq;

namespace PickItEasy.EventBus
{
    public class EventBusConfiguration
    {
        public static string Section = "EventBus";
        public RabbitMqOptions? RabbitMq { get; set; }
    }
}
