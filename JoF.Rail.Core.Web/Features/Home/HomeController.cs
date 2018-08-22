namespace JoF.Rail.Core.Web.Features.Home
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [AllowAnonymous]
        //[Route("Error")]
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ViewData["ErrorUrl"] = feature?.OriginalPath;
            ViewData["ErrorQueryString"] = feature?.OriginalQueryString;

            if (statusCode.HasValue) {
                if (statusCode.Value == 404 || statusCode.Value == 500)
                {
                    var viewName = $"StatusCodes/{statusCode}";
                    return View(viewName);
                }
            }

            return View(new Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Problem()
        {
            return StatusCode(500);
        }
    }
}