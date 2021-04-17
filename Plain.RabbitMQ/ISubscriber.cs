using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plain.RabbitMQ
{
    public interface ISubscriber : IDisposable
    {
        void Subscribe(Func<string, IDictionary<string, object>, bool> callback);
        void SubscribeAsync(Func<string, IDictionary<string, object>, Task<bool>> callback);
    }
}