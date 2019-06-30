namespace JoF.Rail.Feeds.Console
{
    using System;
    using System.Collections.Concurrent;
    using Apache.NMS;
    using JoF.Rail.Service.LiveFeeds;
    using JoF.Rail.Service.LiveFeeds.Models;

    public class Program : IDisposable
    {
        static ConcurrentQueue<dynamic> builder = new ConcurrentQueue<dynamic>();
        static string Topic = "TRAIN_MVT_FREIGHT"; //"TD_SUSS_SIG_AREA"; //"RTPPM_ALL"; //;
        //Subscriber subscriber;

        static void Main(string[] args)
        {            
            var Conn_Model = new ConnectionModel
            {
                User = "web@jofaircloth.co.uk",
                Password = "M5*Fp5LIg#0!",
                Url = "stomp:tcp://datafeeds.networkrail.co.uk:61618"
            };

            var connectionFactory = new ConnectionFactory(new NMSConnectionFactory(Conn_Model.Url)); // Apache.NMS.ActiveMQ.ConnectionFactory(Conn_Model.Url));

            var connection = connectionFactory.CreateTopicConnection(Conn_Model);

            var subscriber = connection.CreateTopicSubscriber(Topic, Conn_Model.User);
            subscriber.OnMessageReceived += new MessageReceivedDelegate(OnMessageReceived);

            Console.WriteLine("Hello World!");
            Console.ReadKey();

            subscriber.Dispose();
            connection.Dispose();
        }

        private static void OnMessageReceived(IMessage message)
        {
            var obj = message as dynamic; //.Text;

            if (obj != null)
            {
                Console.WriteLine(obj.Text);
//                builder.Enqueue(obj.Text);
            }
        }

        public void Dispose()
        {
            //subscriber.Dispose();
//            throw new NotImplementedException();
        }
    }
}
