using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Montrium.Connect.EventBus.Events;

namespace Montrium.Connect.EventBus.Abstractions
{
    public interface IEventBusSubscriptionManager
    {
        event EventHandler<string> OnEventRemoved;
        bool IsEmpty { get; }
        void Clear();
        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
        void RemoveSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
        string GetEventKey<T>();




    }
}
