namespace JoF.Rail.Core.Web.Features.LiveTimes
{
    using Microsoft.AspNetCore.Mvc;

    public class LiveTimesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}