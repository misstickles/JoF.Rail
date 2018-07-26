namespace JoF.Rail.Core.Web.Infrastructure
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;

    public class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //if (!context.ModelState.IsValid)
            //{
            //    if (context.HttpContext.Request.Method == "GET")
            //    {
            //        var result = new BadRequestResult();
            //        context.Result = result;
            //    }
            //    else
            //    {
            //        // context.Result = new BadRequestObjectResult(context.ModelState);
            //        var result = new ContentResult();

            //        string content = JsonConvert.SerializeObject(
            //            context.ModelState,
            //            new JsonSerializerSettings
            //            {
            //                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //            });

            //        result.Content = content;
            //        result.ContentType = "application/json";

            //        context.HttpContext.Response.StatusCode = 400;
            //        context.Result = result;
            //    }
            //}
        }
    }
}
