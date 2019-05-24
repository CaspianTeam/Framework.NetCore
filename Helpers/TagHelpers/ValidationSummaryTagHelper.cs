using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CaspianTeam.Framework.NetCore.Helpers.TagHelpers
{
    /// <summary>
    /// <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper" /> implementation targeting any HTML element with an <c>ct-validation-summary</c>
    /// attribute.
    /// </summary>
    [HtmlTargetElement("div", Attributes = "ct-validation-summary")]
    public class ValidationSummaryTagHelper : TagHelper
    {
        private const string ValidationSummaryAttributeName = "ct-validation-summary";
        private ValidationSummary _validationSummary;

        /// <inheritdoc />
        public override int Order
        {
            get
            {
                return -1000;
            }
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// If <see cref="F:Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All" /> or <see cref="F:Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly" />, appends a validation
        /// summary. Otherwise (<see cref="F:Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.None" />, the default), this tag helper does nothing.
        /// </summary>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if setter is called with an undefined <see cref="P:Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.ValidationSummary" /> value e.g.
        /// <c>(ValidationSummary)23</c>.
        /// </exception>
        [HtmlAttributeName("ct-validation-summary")]
        public ValidationSummary ValidationSummary
        {
            get
            {
                return this._validationSummary;
            }
            set
            {
                if ((uint)value > 2U)
                    throw new ArgumentException(ValidationSummaryTagHelperResources.FormatInvalidEnumArgument((object)nameof(value), (object)value, (object)typeof(ValidationSummary).FullName), nameof(value));
                this._validationSummary = value;
            }
        }

        /// <inheritdoc />
        /// <remarks>Does nothing if <see cref="P:Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.ValidationSummary" /> is <see cref="F:Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.None" />.</remarks>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            if (this.ValidationSummary == ValidationSummary.None)
                return;

            // تغیر توسط حسام محمودی برای سازگاری با AjaxForm
            //TagBuilder validationSummary = this.Generator.GenerateValidationSummary(this.ViewContext, this.ValidationSummary == ValidationSummary.ModelOnly, (string)null, (string)null, (object)null);
            TagBuilder validationSummary = ValidationSummaryTagHelperResources.GenerateValidationSummary(this.ViewContext, this.ValidationSummary == ValidationSummary.None, ValidationSummary == ValidationSummary.All, (string)null, (string)null, (object)null);

            if (validationSummary == null)
            {
                output.SuppressOutput();
            }
            else
            {
                output.MergeAttributes(validationSummary);
                if (!validationSummary.HasInnerHtml)
                    return;
                output.PostContent.AppendHtml((IHtmlContent)validationSummary.InnerHtml);
            }
        }
    }

    internal static class ValidationSummaryTagHelperResources
    {
        private static readonly ResourceManager _resourceManager = new ResourceManager("CaspianTeam.Framework.NetCore.Helpers.TagHelpers.ValidationSummaryTagHelperResources", typeof(ValidationSummaryTagHelperResources).GetTypeInfo().Assembly);

        /// <summary>
        /// The value of argument '{0}' ({1}) is invalid for Enum type '{2}'.
        /// </summary>
        internal static string FormatInvalidEnumArgument(object p0, object p1, object p2)
        {
            return string.Format((IFormatProvider)CultureInfo.CurrentCulture, ValidationSummaryTagHelperResources.GetString("InvalidEnumArgument"), p0, p1, p2);
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            string str = ValidationSummaryTagHelperResources._resourceManager.GetString(name);
            if (formatterNames != null)
            {
                for (int index = 0; index < formatterNames.Length; ++index)
                    str = str.Replace("{" + formatterNames[index] + "}", "{" + (object)index + "}");
            }
            return str;
        }


        internal static TagBuilder GenerateValidationSummary(
            ViewContext viewContext,
            bool excludePropertyErrors,
            bool isValidationSummaryAll,// اضافه کردن توسط حسام محمودی برای سازگاری با AjaxForm
            string message,
            string headerTag,
            object htmlAttributes)
        {
            if (viewContext == null)
                throw new ArgumentNullException(nameof(viewContext));
            ViewDataDictionary viewData = viewContext.ViewData;
            if (!viewContext.ClientValidationEnabled && viewData.ModelState.IsValid)
                return (TagBuilder)null;
            ModelStateEntry modelStateEntry1;
            if (excludePropertyErrors && (!viewData.ModelState.TryGetValue(viewData.TemplateInfo.HtmlFieldPrefix, out modelStateEntry1) || modelStateEntry1.Errors.Count == 0))
                return (TagBuilder)null;
            TagBuilder tagBuilder1;
            if (string.IsNullOrEmpty(message))
            {
                tagBuilder1 = (TagBuilder)null;
            }
            else
            {
                if (string.IsNullOrEmpty(headerTag))
                    headerTag = viewContext.ValidationSummaryMessageElement;
                tagBuilder1 = new TagBuilder(headerTag);
                tagBuilder1.InnerHtml.SetContent(message);
            }
            bool flag = false;
            IList<ModelStateEntry> modelStateList = ValidationHelpers.GetModelStateList(viewData, excludePropertyErrors);
            TagBuilder tagBuilder2 = new TagBuilder("ul");
            foreach (ModelStateEntry modelStateEntry2 in (IEnumerable<ModelStateEntry>)modelStateList)
            {
                for (int index = 0; index < modelStateEntry2.Errors.Count; ++index)
                {
                    string messageOrDefault = ValidationHelpers.GetModelErrorMessageOrDefault(modelStateEntry2.Errors[index]);
                    if (!string.IsNullOrEmpty(messageOrDefault))
                    {
                        TagBuilder tagBuilder3 = new TagBuilder("li");
                        tagBuilder3.InnerHtml.SetContent(messageOrDefault);
                        tagBuilder2.InnerHtml.AppendLine((IHtmlContent)tagBuilder3);
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                tagBuilder2.InnerHtml.AppendHtml("<li style=\"display:none\"></li>");
                tagBuilder2.InnerHtml.AppendLine();
            }
            TagBuilder tagBuilder4 = new TagBuilder("div");
            tagBuilder4.MergeAttributes<string, object>(GetHtmlAttributeDictionaryOrNull(htmlAttributes));
            if (viewData.ModelState.IsValid)
                tagBuilder4.AddCssClass(HtmlHelper.ValidationSummaryValidCssClassName);
            else
                tagBuilder4.AddCssClass(HtmlHelper.ValidationSummaryCssClassName);
            if (tagBuilder1 != null)
                tagBuilder4.InnerHtml.AppendLine((IHtmlContent)tagBuilder1);
            tagBuilder4.InnerHtml.AppendHtml((IHtmlContent)tagBuilder2);
            if (viewContext.ClientValidationEnabled && !excludePropertyErrors)
                // تغیر توسط حسام محمودی برای سازگاری با AjaxForm
                //tagBuilder4.MergeAttribute("data-valmsg-summary", "true");
                tagBuilder4.MergeAttribute("data-valmsg-summary", isValidationSummaryAll.ToString().ToLower());
            return tagBuilder4;
        }

        private static IDictionary<string, object> GetHtmlAttributeDictionaryOrNull(
            object htmlAttributes)
        {
            IDictionary<string, object> dictionary = (IDictionary<string, object>)null;
            if (htmlAttributes != null)
                dictionary = htmlAttributes as IDictionary<string, object> ?? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return dictionary;
        }
    }
}