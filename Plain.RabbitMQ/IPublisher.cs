using System;
using System.Collections.Generic;

namespace Plain.RabbitMQ
{
    public interface IPublisher : IDisposable
    {
        void Publish(string message, string routingKey, IDictionary<string, object> messageAttributes, string timeToLive = null);
    }
}