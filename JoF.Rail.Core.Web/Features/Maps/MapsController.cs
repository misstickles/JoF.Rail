namespace JoF.Rail.Core.Web.Features.Maps
{
    using Microsoft.AspNetCore.Mvc;

    public class MapsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Station()
        {
            return View();
        }
    }
}