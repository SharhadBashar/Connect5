using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrium.Connect.MessageBus.EventBusRabbitMQ
{
    public class Consumer
    {
        /// <summary>
        /// This illustrates how you can consume the data previously stored in the queue.
        /// With the RabbitMQ service running locally in your system, 
        /// use the following method to consume data in the queue.
        /// </summary>
        /// <param name="queue"></param>
        public void Receive(string queue)
        {
            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    BasicGetResult result = channel.BasicGet(queue, true);
                    if (result != null)
                    {
                        string data =
                        Encoding.UTF8.GetString(result.Body);
                        Console.WriteLine(data);
                    }
                }
            }
        }
    }
}
