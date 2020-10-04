using RabbitMQ.Client;
using System;

namespace Plain.RabbitMQ
{
    public interface IConnectionProvider : IDisposable
    {
        IConnection GetConnection();
    }
}