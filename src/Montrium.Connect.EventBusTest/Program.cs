using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Montrium.Connect.MessageBus.EventBusRabbitMQ
{
    public class Program
    {
        private static string host = "http://localhost:8080";
        private static string username = "guest";
        private static string password = "guest";
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();

            // =================================================
            // RabbitMQ server is running locally in your system, 
            // the following code snippet can be used to create a connection to RabbitMQ server.
            //ConnectionFactory connectionFactory = new ConnectionFactory();
            //IConnection connection = connectionFactory.CreateConnection();


            //Connector currentConnection = new Connector();
            Publisher publish = new Publisher();
            Consumer consume = new Consumer();

            //currentConnection.GetConnection(host, username, password);
            
            // This shows how you can call the Send and the Receive methods we created in this post
            publish.Send("StudyMessage", "Study Created!!! Do stuff.");
            consume.Receive("StudyMessage");
            //Console.ReadLine();
            // =================================================

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
