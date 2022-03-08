using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AspNetCoreRabbitMQ.Services
{
    public class RabbitMQReceiverService : IDisposable
    {
        private readonly ILogger<RabbitMQReceiverService> _logger;

        private IServiceProvider _sp;
        private ConnectionFactory _factory;
        private IConnection _connection;
        const string _queue_name = "hello";

        public IModel _channel { get; private set; }

        public void SendMessageToRabbitMQ(string _sendedMessage)
        {
            _channel.BasicPublish(exchange: "",
                routingKey: _queue_name,
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(_sendedMessage));
        }
        public string? ReceivedMessageFromRabbitMQ { get; private set; }

        public RabbitMQReceiverService(IServiceProvider sp, ILogger<RabbitMQReceiverService> logger)
        {
            _logger = logger;
            _sp = sp;

            //---

            _logger.LogInformation("RabbitMQReceiverService");

            //---

            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "test",
                Password = "0"

            };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queue_name,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                ReceivedMessageFromRabbitMQ = message;
            };
            _channel.BasicConsume(queue: _queue_name,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void Dispose()
        {
            _logger.LogInformation("RabbitMQReceiverService. Dispose");

            _channel.Dispose();
            _connection.Dispose();
        }
    }
}
