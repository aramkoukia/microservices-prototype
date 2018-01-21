using EasyNetQ;
using System;

namespace MicroServices.Common.MessageBus
{
    public class TransientSubscriber : IDisposable
    {
        private ISubscriptionResult subscription;

        private readonly Action handler;
        private readonly string topic;
        private readonly string listenerName;

        public TransientSubscriber(string listenerName, string topic, Action handler)
        {
            this.listenerName = listenerName;
            this.topic = topic;
            this.handler = handler;

            InitializeBus();
        }

        private void InitializeBus()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            subscription = bus.Subscribe<PublishedMessage>(listenerName, m => handler(), q => q.WithTopic(topic));
        }

        public void Dispose()
        {
            subscription.Dispose();
        }
    }
}
