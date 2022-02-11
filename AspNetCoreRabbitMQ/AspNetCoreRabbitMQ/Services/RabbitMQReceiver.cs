using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AspNetCoreRabbitMQ.Services
{
    public class RabbitMQReceiverService : BackgroundService
    {
        private readonly ILogger<RabbitMQReceiverService> _logger;

        private IServiceProvider _sp;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public string ReceivedMessage { get; set; }

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
            _channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                ReceivedMessage = message;
            };
            _channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ExecuteAsync. ReceivedMessage=" + ReceivedMessage);

            return Task.CompletedTask;
        }
    }
}
