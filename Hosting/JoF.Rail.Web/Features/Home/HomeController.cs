namespace JoF.Rail.Web.Features.Home
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return this.View("Privacy");
        }

        [AllowAnonymous]
        public IActionResult Error(int? statusCode = null)
        {
            var feature = this.HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            this.ViewData["ErrorUrl"] = feature?.OriginalPath;
            this.ViewData["ErrorQueryString"] = feature?.OriginalQueryString;

            if (statusCode.HasValue) {
                if (statusCode.Value == 404 || statusCode.Value == 500)
                {
                    var viewName = $"StatusCodes/{statusCode}";
                    return this.View(viewName);
                }
            }

            return this.View(new Error { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Problem()
        {
            return this.StatusCode(500);
        }
    }
}