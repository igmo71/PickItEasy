using Microsoft.Extensions.Options;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Domain.Entities.WhsOrder.Out;
using RabbitMQ.Client;
using Serilog;
using System.Text;
using System.Text.Json;

namespace PickItEasy.EventBus.RabbitMq
{
    public class WhsOrderOutPublisher : IEventBusPublisher
    {
        private readonly EventBusConfiguration _options;

        public WhsOrderOutPublisher(IOptions<EventBusConfiguration> options)
        {
            _options = options.Value;
        }

        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = _options.RabbitMq?.HostName };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: nameof(WhsOrderOut),
                           durable: false,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                           routingKey: nameof(WhsOrderOut),
                           basicProperties: null,
                           body: body);

            Log.Debug("PickItEasy {Publisher}:  {message}", nameof(WhsOrderOutPublisher), message);
        }
    }
}
