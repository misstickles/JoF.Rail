namespace JoF.Rail.Tests.xUnit.DarwinFeed
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using Apache.NMS;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Service.LiveFeeds;
    using JoF.Rail.Service.LiveFeeds.Models;
    using RttiPPT;
    using Xunit;
    using ConnectionFactory = JoF.Rail.Service.LiveFeeds.ConnectionFactory;

    public class QueueSubscriberTests : IDisposable
    {
        private readonly ConnectionFactory connectionFactory;
        private QueueConnection connection;
        private Subscriber subscriber;
        private readonly ConcurrentQueue<Pport> builder = new ConcurrentQueue<Pport>();

        private ConnectionModel Conn_Model = new ConnectionModel
        {
            User = "d3user",
            Password = "d3password",
            Queue = "D3256b5287-960c-466d-981e-b388aeae4908",
            Url = "activemq:tcp://datafeeds.nationalrail.co.uk:61616"
        };

        public QueueSubscriberTests()
        {
            this.connectionFactory = new ConnectionFactory(new Apache.NMS.ActiveMQ.ConnectionFactory(this.Conn_Model.Url));
        }

        [Fact]
        public void QueueSubscriber()
        {
            this.connection = this.connectionFactory.CreateQueueConnection(Conn_Model);
            this.subscriber = this.connection.CreateQueueSubscriber();
            this.subscriber.OnMessageReceived += new MessageReceivedDelegate(OnMessageReceived);

            var time0 = DateTime.Now.Ticks;
            var time = time0;

            while (time < time0 + 100 * 10000000)
            {
                time = DateTime.Now.Ticks;
                Task.Delay(500);
            }
        }

        private void OnMessageReceived(IMessage message)
        {
            var bytesMessage = message as IBytesMessage;
            var obj = bytesMessage.Content.ToString<Pport>();

            if (obj != null)
            {
                this.builder.Enqueue(obj);
            }
        }

        public void Dispose()
        {
            this.subscriber.Dispose();
            this.connection.Dispose();
        }
    }
}
