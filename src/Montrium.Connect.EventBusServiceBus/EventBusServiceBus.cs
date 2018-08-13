using Autofac;
using Microsoft.Azure.ServiceBus;
using Montrium.Connect.EventBus;
using Montrium.Connect.EventBus.Abstractions;
using Montrium.Connect.EventBus.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Montrium.Connect.EventBusServiceBus
{
    public class EventBusServiceBus : IEventBus
    {
        // WIP for all
        public void Publish(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}
