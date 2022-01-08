namespace AppForTests.Helpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("table", Attributes = "bootstrap-table")]
    public class BootstrapTableTagHelper : TagHelper
    {        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add(new TagHelperAttribute("class", "table table-stripped table-hover table-sm"));
        }
    }
}
