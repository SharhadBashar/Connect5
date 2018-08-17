using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Montrium.Connect.PDF.Shared.Events;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace Montrium.Connect.PDF.Web.Services
{
    public class EventPublisher : IEventPublisher
    {
        private readonly CloudQueue _queue;

        public EventPublisher(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);

            var queueClient = storageAccount.CreateCloudQueueClient();

            _queue = queueClient.GetQueueReference("eventqueue");
        }
        public async Task Publish(IEvent @event)
        {
            await _queue.CreateIfNotExistsAsync();
            var message = new CloudQueueMessage(JsonConvert.SerializeObject(@event));
            await _queue.AddMessageAsync(message);

        }
    }
}
