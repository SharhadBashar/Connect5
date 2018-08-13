using System;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;

namespace Montrium.Connect.EventBusServiceBus
{
    public class ServiceBusPersistentConnection : IServicePersistentConnection
    {
        private readonly ILogger<ServiceBusPersistentConnection> _logger;
        private readonly ServiceBusConnectionStringBuilder _serviceBusConnectionStringBuilder;
        private ITopicClient _topicClient;
        bool _disposed;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceBusConnectionStringBuilder"></param>
        /// <param name="logger"></param>
        public ServiceBusPersistentConnection(ServiceBusConnectionStringBuilder serviceBusConnectionStringBuilder, ILogger<ServiceBusPersistentConnection> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceBusConnectionStringBuilder = serviceBusConnectionStringBuilder ?? throw new ArgumentNullException(nameof(serviceBusConnectionStringBuilder));
            _topicClient = new TopicClient(_serviceBusConnectionStringBuilder, RetryPolicy.Default);
        }

        /// <summary>
        /// 
        /// </summary>
        public ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder => _serviceBusConnectionStringBuilder;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ITopicClient CreateModel()
        {
            if (_topicClient.IsClosedOrClosing)
            {
                _topicClient = new TopicClient(_serviceBusConnectionStringBuilder, RetryPolicy.Default);
            }

            return _topicClient;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;
        }
    }
}
