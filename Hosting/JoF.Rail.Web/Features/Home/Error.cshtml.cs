namespace JoF.Rail.Web.Features
{
    public class Error
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
