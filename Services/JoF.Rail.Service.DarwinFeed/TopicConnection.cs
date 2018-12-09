namespace JoF.Rail.Service.LiveFeeds
{
    using System;
    using Apache.NMS;
    using Apache.NMS.ActiveMQ.Commands;
    using JoF.Rail.Service.LiveFeeds.Models;

    public class TopicConnection : IDisposable
    {
        private readonly IConnection connection;
        private readonly ISession session;
        private readonly ITopic topic;
        private readonly string selector;
        private bool isDisposed = false;

        public TopicConnection(
            IConnectionFactory connectionFactory,
            ConnectionModel connectionData)
        {
            this.connection = connectionFactory.CreateConnection(connectionData.User, connectionData.Password);
            this.connection.ExceptionListener += new ExceptionListener(OnConnectionException);
            this.connection.ClientId = connectionData.User; // .ClientId;
            this.connection.Start();
            this.session = this.connection.CreateSession();
            this.topic = new ActiveMQTopic(connectionData.TopicName);
            this.selector = connectionData.Selector;
        }

        private void OnConnectionException(Exception exception)
        {
            // TODO: connection exception
        }

        public Subscriber CreateTopicSubscriber(string consumerId)
        {
            var consumer = this.session.CreateConsumer(this.topic, this.selector, false);
            return new Subscriber(consumer);
        }

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.session.Close();
                this.session.Dispose();
                this.connection.Stop();
                this.connection.Close();
                this.connection.Dispose();

                this.isDisposed = true;
            }
        }
    }
}
