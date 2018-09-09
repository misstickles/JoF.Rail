namespace JoF.Rail.Web.Features.Maps
{
    using Microsoft.AspNetCore.Mvc;

    public class MapsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Station()
        {
            return this.View();
        }
    }
}