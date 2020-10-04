using System;
using System.Collections.Generic;

namespace Plain.RabbitMQ
{
    public interface ISubscriber : IDisposable
    {
        void Subscribe(Func<string, IDictionary<string, object>, bool> callback);
    }
}