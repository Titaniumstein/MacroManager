using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using System.ServiceModel;
using System.Diagnostics;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using MacroContext.Contract.Events;
using MacroManager.Infrastructure.Abstractions;

namespace MacroManager.Infrastructure.Services.MacroContext
{
    public class EventCallback : IDisposable
    {
        private EventProcessor _evenProcessor;
        private IConnection _connection;

        public EventCallback(EventProcessor eventProcessor)
        {
            _evenProcessor = eventProcessor;
        }


        public void CreateConnection()
        {
            var uri = new Uri("amqp://MacroAdmin:macro@localhost:5672/MacroManager");
            var factory = new ConnectionFactory() { Uri = uri};
            _connection = factory.CreateConnection();
        }

        public void SubscribeToMessages()
        {

            var channel = _connection.CreateModel();
            channel.ExchangeDeclare(exchange: "direct_events", type: ExchangeType.Direct);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                                     exchange: "direct_events",
                                     routingKey: "");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Message_Received;

            channel.BasicConsume(queue: queueName,
                                    autoAck: true,
                                    consumer: consumer);

        }

        private void Message_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            String jsonified = Encoding.UTF8.GetString(e.Body);
            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var message = JsonConvert.DeserializeObject<TransactionResult>(jsonified, jsonSerializerSettings);

            _evenProcessor.Process(message);

        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
