using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AspNetCoreRabbitMQ_win_forms
{
    public partial class Form1 : Form
    {
        string m_received_message;
        readonly IConnection? _connection;
        readonly IModel? _channel;

        public Form1()
        {
            InitializeComponent();

            //---

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "test",
                Password = "0"

            };
            _connection = factory.CreateConnection();
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
                //_ReceivedMessage 
                m_received_message
                = message;
            };
            _channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);

        }

        private void vsl_send_Click(object sender, EventArgs e)
        {
            string message =
                //_SendedMessage
                //DateTime.Now.ToString()
                vsl_txt_send.Text
                ;
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            vsl_received_message.Text = m_received_message;
        }
    }
}