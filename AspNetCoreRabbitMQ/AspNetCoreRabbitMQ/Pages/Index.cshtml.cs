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
            _rabbitMQReceiverService.SendMessageToRabbitMQ(SendedMessage);
        }
        public void OnPostReceiveMessageFromRabbitMQ()
        {
            ReceivedMessage = _rabbitMQReceiverService.ReceivedMessageFromRabbitMQ;
        }
    }
}