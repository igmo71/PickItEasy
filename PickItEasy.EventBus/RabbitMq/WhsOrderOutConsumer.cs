using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

namespace PickItEasy.EventBus.RabbitMq
{
    public class WhsOrderOutConsumer : BackgroundService, IEventBusConsumer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventBusConfiguration _options;

        public static event EventHandler<string>? MessageReceived;

        public WhsOrderOutConsumer(IOptions<EventBusConfiguration> options)
        {
            _options = options.Value;
            var factory = new ConnectionFactory { HostName = _options.RabbitMq?.HostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: nameof(WhsOrderOut),
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, eventArgs) =>
            {
                var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

                Log.Debug("PickItEasy {Consumer}:  {message}", nameof(WhsOrderOutConsumer), message);

                OnMessageReceived(message);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(queue: nameof(WhsOrderOut),
                autoAck: false,
                consumer: consumer);

            return Task.CompletedTask;
        }

        private void OnMessageReceived(string content)
        {
            MessageReceived?.Invoke(this, content);
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
