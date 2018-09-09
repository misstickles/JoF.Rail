namespace JoF.Rail.Web.Features.NetworkOverview
{
    using System.Threading.Tasks;
    using JoF.Rail.Web.Consts;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class NetworkOverviewController : Controller
    {
        private readonly IMediator mediator;

        private readonly IConfiguration configuration;

        public NetworkOverviewController(IMediator mediator, IConfiguration configuration)
        {
            this.mediator = mediator;

            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            //if (string.IsNullOrEmpty(Request.Cookies["KbToken"]))
            //{
                var token = await this.mediator.Send(new Index.Token
                {
                    Key = this.configuration[ConfigKey.NatRail.Key],
                    Url = this.configuration[ConfigKey.NatRail.KbTokenUrl],
                    User = this.configuration[ConfigKey.NatRail.User]
                });

                //var cookieOptions = new CookieOptions
                //{
                //    Expires = DateTime.Now.AddMinutes(59),
                //    HttpOnly = true
                //};

                //// strip out username and store in cookie
                //this.Response.Cookies.Append(
                //    "KbToken",
                //    // token.Token.Contains(token.UserName + ":") ? token.Token.Replace(token.UserName + ":", string.Empty) : string.Empty,
                //    "test",
                //    cookieOptions);
            //}

            var network = await this.mediator.Send(new Index.Query
            {
                Token = token.Token,
                Url = this.configuration[ConfigKey.NatRail.KbUrl] + this.configuration[ConfigKey.NatRail.ServiceIndicator]
            });

            return this.View(network);
        }
    }
}