using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Montrium.Connect.EventBus.Events;

namespace Montrium.Connect.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<T, TH>() where T :  IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void Unsubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    }
}
