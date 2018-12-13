namespace JoF.Rail.Service.LiveFeeds
{
    using System;
    using Apache.NMS;
    using JoF.Rail.Service.LiveFeeds.Models;

    public class QueueConnection : IDisposable
    {
        private readonly IConnection connection;
        private readonly ISession session;
        private readonly IQueue queue;
        private readonly string selector;
        private bool isDisposed = false;

        public QueueConnection(
            IConnectionFactory connectionFactory,
            ConnectionModel connectionData)
        {
            this.connection = connectionFactory.CreateConnection(connectionData.User, connectionData.Password);
            this.connection.ExceptionListener += new ExceptionListener(OnConnectionException);
            this.connection.Start();
            this.session = this.connection.CreateSession();
            this.queue = this.session.GetQueue(connectionData.Queue);
            this.selector = connectionData.Selector;
        }

        private void OnConnectionException(Exception exception)
        {
            // TODO: connection exception
        }

        public Subscriber CreateQueueSubscriber()
        {
            var consumer = this.session.CreateConsumer(this.queue, selector);
            return new Subscriber(consumer);
        }

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.session.Dispose();
                this.connection.Dispose();
                this.isDisposed = true;
            }
        }
    }
}
