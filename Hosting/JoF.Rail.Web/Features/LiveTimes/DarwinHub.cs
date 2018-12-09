namespace JoF.Rail.Core.Web.Features.LiveTimes
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    public class DarwinHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
