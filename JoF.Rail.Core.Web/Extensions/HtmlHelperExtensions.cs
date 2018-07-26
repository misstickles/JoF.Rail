namespace JoF.Rail.Core.Web.Extensions
{
    using System;
    using System.Linq.Expressions;
    using HtmlTags;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class HtmlHelperExtensions
    {
        public static HtmlTag ValidationDiv(this IHtmlHelper helper)
        {
            return new HtmlTag("div")
                .Id("validationSummary")
                .AddClass("alert")
                .AddClass("alert-danger")
                .AddClass("hidden");
        }

        public static HtmlTag FormBlock<T, TMember>(
            this IHtmlHelper<T> helper,
            Expression<Func<T, TMember>> expression,
            Action<HtmlTag> labelModifier = null,
            Action<HtmlTag> inputModifier = null)
            where T : class
        {
            labelModifier = labelModifier ?? (_ => { });
            inputModifier = inputModifier ?? (_ => { });

            var divTag = new HtmlTag("div")
                .AddClass("form-group");

            var labelTag = helper.Label(expression);
            labelModifier(labelTag);

            var inputTag = helper.Input(expression);
            inputModifier(inputTag);

            divTag.Append(labelTag);
            divTag.Append(inputTag);
            //divTag.Append(helper.ValidationMessage(expression));

            return divTag;
        }
    }
}
