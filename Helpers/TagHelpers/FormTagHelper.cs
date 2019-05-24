using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CaspianTeam.Framework.NetCore.Helpers.TagHelpers
{
    [HtmlTargetElement("form")]
    public class FormTagHelper : TagHelper
    {       
        /// <summary>
        /// Get JavaScript EXTRA DATA OBJECT NAME which cannot be supplied by the form elements.
        /// </summary>
        [HtmlAttributeName("ct-extra-data-obj")]
        public string ExtraDataObjectName { get; set; }

        /// <summary>
        /// The global value in ajax option. Default is true
        /// </summary>
        [HtmlAttributeName("ct-global-ajax")]
        public bool GlobalAjax { get; set; } = true;

        /// <summary>
        /// Attribute to disable JQuery-Form plugin for a form.
        /// </summary>
        [HtmlAttributeName("ct-disable-ajaxform")]
        public bool JqueryFormPluginDisabled { get; set; } = false;

        /// <summary>
        /// Attribute to set focus on a Textbox - Specially after modal opening
        /// </summary>
        [HtmlAttributeName("ct-set-focus-for")]
        public ModelExpression SetFocusOnElement { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (!string.IsNullOrEmpty(SetFocusOnElement?.Name)) 
                output.Attributes.SetAttribute("data-focus", SetFocusOnElement.Name);
            if (!string.IsNullOrWhiteSpace(ExtraDataObjectName))
                output.Attributes.SetAttribute("data-extra", ExtraDataObjectName);
            if (!GlobalAjax)
                output.Attributes.SetAttribute("data-global", GlobalAjax.ToString().ToLower());
            if (JqueryFormPluginDisabled)
                output.Attributes.SetAttribute("data-jqform", (!JqueryFormPluginDisabled).ToString().ToLower());
        }
    }
}
