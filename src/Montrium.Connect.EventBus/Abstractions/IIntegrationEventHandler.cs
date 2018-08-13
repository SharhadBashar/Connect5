using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Montrium.Connect.EventBus.Events;

namespace Montrium.Connect.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
    public interface IIntegrationEventHandler
    {

    }
}
