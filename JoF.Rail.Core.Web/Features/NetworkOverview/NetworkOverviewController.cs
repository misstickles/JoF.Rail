namespace JoF.Rail.Core.Web.Features.NetworkOverview
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class NetworkOverviewController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}