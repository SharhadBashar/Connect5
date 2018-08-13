using Montrium.Connect.EventBus;
using System;
using System.Linq;
using Xunit;

namespace Montrium.Connect.EventBus.Tests
{
    public class SubscriptionManagerTests
    {
        [Fact]
        public void After_Creation_Should_Be_Empty()
        {
            var subscriptionManager = new EventBusSubscriptionManager();
            Assert.True(subscriptionManager.IsEmpty);
        }

        [Fact]
        public void After_One_Event_Subscription_Should_Contain_The_Event()
        {
            var subscriptionManager = new EventBusSubscriptionManager();
            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.True(subscriptionManager.HasSubscriptionsForEvent<TestIntegrationEvent>());
        }

        [Fact]
        public void After_All_Subscriptions_Are_Deleted_Events_Should_No_Longer_Exists()
        {
            var subscriptionManager = new EventBusSubscriptionManager();
            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            subscriptionManager.RemoveSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.False(subscriptionManager.HasSubscriptionsForEvent<TestIntegrationEvent>());
        }

        [Fact]
        public void Deleting_Last_Subscription_Should_Raise_On_Deleted_Event()
        {
            bool raised = false;
            var subscriptionManager = new EventBusSubscriptionManager();
            subscriptionManager.OnEventRemoved += (o, e) => raised = true;
            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            subscriptionManager.RemoveSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.True(raised);
        }

        [Fact]
        public void Get_Handlers_For_Event_Should_Return_All_Handlers()
        {
            var subscriptionManager = new EventBusSubscriptionManager();
            subscriptionManager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            subscriptionManager.AddSubscription<TestIntegrationEvent, TestOtherIntegrationEventHandler>();
            var handlers = subscriptionManager.GetHandlersForEvent<TestIntegrationEvent>();
            Assert.Equal(2, handlers.Count());
        }
    }
}
