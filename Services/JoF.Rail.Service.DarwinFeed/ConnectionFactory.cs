namespace JoF.Rail.Service.LiveFeeds
{
    using Apache.NMS;
    using JoF.Rail.Service.LiveFeeds.Models;

    public class ConnectionFactory
    {
        private readonly IConnectionFactory connectionFactory;

        public ConnectionFactory(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public TopicConnection CreateTopicConnection(ConnectionModel connection)
        {
            return new TopicConnection(connectionFactory, connection);
        }

        public QueueConnection CreateQueueConnection(ConnectionModel connection)
        {
            return new QueueConnection(this.connectionFactory, connection);
        }
    }
}
