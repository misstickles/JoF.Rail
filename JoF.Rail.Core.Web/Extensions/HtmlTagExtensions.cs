namespace JoF.Rail.Core.Web.Extensions
{
    using HtmlTags;

    public static class HtmlTagExtensions
    {
        public static HtmlTag AddPlaceholder(this HtmlTag tag, string placeholder)
        {
            return tag.Attr("placeholder", placeholder);
        }

        public static HtmlTag AutoCapitalise(this HtmlTag tag)
        {
            return tag.Data("autocapitalize", "true");
        }
    }
}
