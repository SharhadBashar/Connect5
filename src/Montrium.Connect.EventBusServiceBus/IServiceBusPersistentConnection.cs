using Microsoft.Azure.ServiceBus;

namespace Montrium.Connect.EventBusServiceBus
{
    public interface IServicePersistentConnection
    {
        ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }
        ITopicClient CreateModel();
    }
}
