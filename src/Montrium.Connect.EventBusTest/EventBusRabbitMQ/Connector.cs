using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Montrium.Connect.MessageBus.EventBusRabbitMQ
{
    public class Connector
    {
        /// <summary>
        /// If RabbitMQ service is running in a remote system.
        /// Here's a method that returns you a connection instance to the RabbitMQ service.
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IConnection GetConnection(string hostName, string userName, string password)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            connectionFactory.UserName = userName;
            connectionFactory.Password = password;
            return connectionFactory.CreateConnection();
        }
    }
}
