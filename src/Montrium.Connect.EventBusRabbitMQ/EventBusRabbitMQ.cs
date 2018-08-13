using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Montrium.Connect.EventBus;
using Montrium.Connect.EventBus.Abstractions;
using Montrium.Connect.EventBus.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Montrium.Connect.EventBusRabbitMQ
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        const string BROKER_NAME = "Montrium_Connect_Event_Bus";

        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ILogger<EventBusRabbitMQ> _logger;
        private readonly IEventBusSubscriptionManager _subsManager;
        private readonly ILifetimeScope _autofac;
        private readonly string AUTOFAC_SCOPE_NAME = "Montrium_Connect_Event_Bus";
        private readonly int _retryCount;

        private IModel _consumerChannel;
        private string _queueName;

        public EventBusRabbitMQ(IRabbitMQPersistentConnection persistentConnection, ILogger<EventBusRabbitMQ> logger, ILifetimeScope autofac, IEventBusSubscriptionManager subsManager, string queueName = null, int retryCount = 5)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _subsManager = subsManager ?? new EventBusSubscriptionManager();
            _queueName = queueName;
            _consumerChannel = CreateConsumerChannel();
            _autofac = autofac;
            _retryCount = retryCount;
            _subsManager.OnEventRemoved += SubsManager_OnEventRemoved;
        }

        //unbind queue, close channel and remove queue name if no subscribers left.
        private void SubsManager_OnEventRemoved(object sender, string eventName)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            using (var channel = _persistentConnection.CreateModel())
            {
                channel.QueueUnbind(queue: _queueName,
                                exchange: BROKER_NAME,
                                routingKey: eventName);
                if (_subsManager.IsEmpty)
                {
                    _queueName = string.Empty;
                    _consumerChannel.Close();
                }
            } 

        }

        public void Publish(IntegrationEvent @event)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var policy = RetryPolicy
                .Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) => 
                {
                    _logger.LogWarning(ex.ToString());
                });

            using (var channel = _persistentConnection.CreateModel())
            {
                var eventName = @event.GetType().Name;

                channel.ExchangeDeclare(exchange: BROKER_NAME, 
                                        type: "direct");

                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                policy.Execute(() =>
                {
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2; //persistent

                    channel.BasicPublish(exchange: BROKER_NAME,
                                        routingKey: eventName,
                                        mandatory: true,
                                        basicProperties: properties,
                                        body: body);
                });

            }

               
        }

        //subcribe to queue
        public void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            var eventName = _subsManager.GetEventKey<T>();
            DoInternalSubscription(eventName);
            _subsManager.AddSubscription<T, TH>();
        }

        //bind queue
        private void DoInternalSubscription(string eventName)
        {
            var containsKey = _subsManager.HasSubscriptionsForEvent(eventName);
            if (!containsKey)
            {
                if (!_persistentConnection.IsConnected)
                {
                    _persistentConnection.TryConnect();
                }

                using (var channel = _persistentConnection.CreateModel())
                {
                    channel.QueueBind(queue: _queueName,
                                    exchange: BROKER_NAME,
                                    routingKey: eventName);
                }
            }
        }

        public void Unsubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            _subsManager.RemoveSubscription<T, TH>();
        }

        public void Dispose()
        {
            if(_consumerChannel != null)
            {
                _consumerChannel.Dispose();
            }

            //_subsManager.Clear();
        }

        public IModel CreateConsumerChannel()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            //maybe use a using to auto dispose if there's an issue.
            var channel = _persistentConnection.CreateModel();

            channel.ExchangeDeclare(exchange: BROKER_NAME, 
                                    type: "direct");

            channel.QueueDeclare(queue: _queueName,
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, eventArgs) =>
            {
                var eventName = eventArgs.RoutingKey;
                var message = Encoding.UTF8.GetString(eventArgs.Body);

                await ProcessEvent(eventName, message);

                channel.BasicAck(eventArgs.DeliveryTag, multiple: false);

            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);

            channel.CallbackException += (sender, eventArgs) =>
            {
                _consumerChannel.Dispose();
                _consumerChannel = CreateConsumerChannel();
            };

            return channel;

        }

        //Process Event to consumer channel (aka whoever is subscribed)
        private async Task ProcessEvent(string eventName, string message)
        {
            if (_subsManager.HasSubscriptionsForEvent(eventName))
            {
                using (var scope = _autofac.BeginLifetimeScope(AUTOFAC_SCOPE_NAME))
                {
                    var subscriptions = _subsManager.GetHandlersForEvent(eventName);
                    foreach (var subscription in subscriptions)
                    {
                        if (subscription.IsDynamic)
                        {
                            //parse message into Json Object then handle the eventdata
                        }
                        else
                        {
                            var eventType = _subsManager.GetEventTypeByName(eventName);
                            var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                            var handler = scope.ResolveOptional(subscription.HandlerType);
                            var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                            await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
                        }
                    }
                }
            }
        }
    }
}
