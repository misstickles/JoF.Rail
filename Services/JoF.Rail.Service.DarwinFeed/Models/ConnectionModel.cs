namespace JoF.Rail.Service.LiveFeeds.Models
{
    public class ConnectionModel
    {
        public string ClientId { get; set; }

        public string TopicName { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string Queue { get; set; }

        public string Url { get; set; }

        public string Selector { get; set; } = "2 > 1";
    }
}
