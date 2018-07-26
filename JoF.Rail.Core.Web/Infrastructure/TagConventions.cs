namespace JoF.Rail.Core.Web.Infrastructure
{
    using System.ComponentModel.DataAnnotations;
    using HtmlTags.Conventions;

    public class TagConventions : HtmlConventionRegistry
    {
        public TagConventions()
        {
            this.Editors.Always.AddClass("form-control");

            this.Labels.Always.AddClass("control-label");

            this.ValidationMessages.Always.AddClass("text-danger");
        }
    }
}
