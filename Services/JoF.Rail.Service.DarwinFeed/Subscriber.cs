namespace JoF.Rail.Service.LiveFeeds
{
    using System;
    using Apache.NMS;

    public delegate void MessageReceivedDelegate(IMessage message);

    public class Subscriber : IDisposable
    {
        private readonly IMessageConsumer consumer;
        private bool isDisposed = false;

        public event MessageReceivedDelegate OnMessageReceived;

        public Subscriber(IMessageConsumer consumer)
        {
            this.consumer = consumer;
            this.consumer.Listener += new MessageListener(OnMessage);
        }

        public void OnMessage(IMessage message)
        {
            // TODO: handle all message types

            this.OnMessageReceived?.Invoke(message);
        }

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.consumer.Close();
                this.consumer.Dispose();
                this.isDisposed = true;
            }
        }
    }
}
