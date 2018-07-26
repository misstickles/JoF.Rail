namespace JoF.Rail.Core.Web.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;

    public static class PageModelExtensions
    {
        public static ActionResult RedirectToPageJson<TPage>(this TPage controller, string pageName)
            where TPage : PageModel
        {
            return controller.JsonNet(new
            {
                redirect = controller.Url.Page(pageName)
            });
        }

        public static ContentResult JsonNet(this PageModel controller, object model)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var serialised = JsonConvert.SerializeObject(model, settings);

            return new ContentResult
            {
                Content = serialised,
                ContentType = "application/json"
            };
        }
    }
}
