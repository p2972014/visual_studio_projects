namespace AspNetCoreKafka
{

    using Confluent.Kafka;
    using Kafka.Public;
    using System.Text;

    public partial class Form1 : Form
    {
        const string _topic_name = "test";
        const string _broker_service_path_part = "localhost:9092";
        object _lock = new object();

        IProducer<Null, string>? _Producer;
        ClusterClient? _Consumer;
        Queue<string> _Queue_receiveds = new Queue<string>();

        public Form1()
        {
            InitializeComponent();

            _Producer =
                new ProducerBuilder<Null, string>(
                    new ProducerConfig()
                    {
                        BootstrapServers = _broker_service_path_part
                    })
                    .Build();

            _Consumer = new ClusterClient(
                new Configuration()
                {
                    Seeds = _broker_service_path_part
                },
                new EmptyLogger()
                );
            _Consumer.ConsumeFromLatest(_topic_name);
            _Consumer.MessageReceived += _Consumer_MessageReceived;
        }

        private void vsl_btn_send_Click(object sender, EventArgs e)
        {
            var val_sended = DateTime.Now.ToString() + ". " + vsl_txt_send_text.Text;
            _Producer?.ProduceAsync(topic: _topic_name, new Message<Null, string>() { Value = val_sended });
        }

        private void _Consumer_MessageReceived(RawKafkaRecord obj)
        {
            var val_received = Encoding.UTF8.GetString((obj.Value as byte[]));
            lock (_lock)
            {
                _Queue_receiveds.Enqueue(val_received);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var val_received = (string?)null;
            var is_val_received = false;
            lock (_lock)
            {
                is_val_received = _Queue_receiveds.TryDequeue(out val_received);
            }
            if (is_val_received)
            {
                vsl_txt_receiveds.AppendText(val_received + Environment.NewLine);
            }
        }
    }
    class EmptyLogger : ILogger
    {
        public void LogDebug(string message)
        {

        }

        public void LogError(string message)
        {

        }

        public void LogInformation(string message)
        {

        }

        public void LogWarning(string message)
        {

        }
    }
}