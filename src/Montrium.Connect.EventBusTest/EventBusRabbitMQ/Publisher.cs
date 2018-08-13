using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Montrium.Connect.MessageBus.EventBusRabbitMQ
{
    public class Publisher
    {
        /// <summary>
        /// With the RabbitMQ service running locally in your system, 
        /// use the following method to send messages to a queue.
        /// I’ve passed false as the second parameter to the QueueDeclare method. 
        /// So, the messages sent using this method persist only in the memory and not survive a server restart.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="data"></param>
        public void Send(string queue, string data)
        {
            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
                }
            }
        }       
    }
}
