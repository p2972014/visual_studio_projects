using AspNetCoreRabbitMQ.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreRabbitMQ.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        RabbitMQReceiverService _rabbitMQReceiverService;

        //[DataType(DataType.MultilineText)]
        //[BindProperty]
        public string SendedMessage { get; set; }
        //[DataType(DataType.MultilineText)]
        //[BindProperty]
        public string ReceivedMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, RabbitMQReceiverService rabbitMQReceiverService)
        {
            _logger = logger;
            _rabbitMQReceiverService = rabbitMQReceiverService;
        }

        public void OnGetAsync()
        {        
        }

        public void OnPostSendMessageToRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "test",
                Password = "0"

            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message =
                    SendedMessage
                    //DateTime.Now.ToString()
                    ;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
            }
        }
        public void OnPostReceiveMessageFromRabbitMQ()
        {
            ReceivedMessage = _rabbitMQReceiverService.ReceivedMessage;
        }
    }
}