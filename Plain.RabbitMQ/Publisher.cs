using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plain.RabbitMQ
{
    public class Publisher : IPublisher
    {
        private readonly IConnectionProvider _connectionProvider;
        private readonly string _exchange;
        private readonly IModel _model;
        private bool _disposed;

        public Publisher(IConnectionProvider connectionProvider, string exchange, string exchangeType, int timeToLive = 30000)
        {
            _connectionProvider = connectionProvider;
            _exchange = exchange;
            _model = _connectionProvider.GetConnection().CreateModel();
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl", timeToLive }
            };
            _model.ExchangeDeclare(_exchange, exchangeType, arguments: ttl);
        }

        public void Publish(string message, string routingKey, IDictionary<string, object> messageAttributes, string timeToLive = "30000")
        {
            var body = Encoding.UTF8.GetBytes(message);
            var properties = _model.CreateBasicProperties();
            properties.Persistent = true;
            properties.Headers = messageAttributes;
            properties.Expiration = timeToLive;

            _model.BasicPublish(_exchange, routingKey, properties, body);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _model?.Close();

            _disposed = true;
        }
    }
}