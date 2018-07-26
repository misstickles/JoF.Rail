namespace JoF.Rail.Core.Web.Infrastructure.TagHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("Form-Block", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class FormBlockTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@jo.com";
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{target}");
            output.Content.SetContent(target);
        }
    }
}
