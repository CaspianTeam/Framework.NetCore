using System;
using System.Drawing;
using System.Linq;
using CaspianTeam.Framework.NetCore.Enums.Helpers.TagHelpers.Button;
using CaspianTeam.Framework.NetCore.Enums.Helpers.TagHelpers.Icon;
using CaspianTeam.Framework.NetCore.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CaspianTeam.Framework.NetCore.Helpers.TagHelpers
{
    [HtmlTargetElement("button")]
    public class ButtonTagHelper : TagHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ButtonTagHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Bootstrap Button Type
        /// </summary>
        [HtmlAttributeName("ct-type")]
        public BootstrapButtonType ButtonType { get; set; }

        /// <summary>
        /// Button Icon Name, e.g. user
        /// </summary>
        [HtmlAttributeName("ct-icon")]
        public IconNameType ButtonIconNameType { get; set; }

        /// <summary>
        /// Button icon type, e.g. Light, Brand, Regular, Solid
        /// </summary>
        [HtmlAttributeName("ct-icon-type")]
        public IconType ButtonIconType { get; set; } = IconType.light;

        /// <summary>
        /// Bootstrap Button Size Level (bt-sm, normal, btn-lg). Default is Small
        /// </summary>
        [HtmlAttributeName("ct-size")]
        public BootstrapButtonSizeType ButtonSizeType { get; set; } = BootstrapButtonSizeType.Small;

        /// <summary>
        /// Bootstrap active (appear pressed) class. Default is false
        /// </summary>
        [HtmlAttributeName("ct-active-state")]
        public bool IsActive { get; set; } = false;

        /// <summary>
        /// If button content is in english language or not. Default is false (means it's in persian)
        /// </summary>
        [HtmlAttributeName("ct-english")]
        public bool IsEnglishContent { get; set; } = false;

        /// <summary>
        /// Direction of icon in button. Right or left? Default is Right (persian default)
        /// </summary>
        [HtmlAttributeName("ct-icon-dir")]
        public ButtonIconDirectionType IconDirectionType { get; set; } = ButtonIconDirectionType.Right;

        /// <summary>
        /// Equal to btn-block class in Bootstrap that spans the entire width of the parent element. Default is false
        /// </summary>
        [HtmlAttributeName("ct-full-width")]
        public bool HasBtnBlockClass { get; set; } = false;

        /// <summary>
        /// Bootstrap outline/bordered buttons. Default is false
        /// </summary>
        [HtmlAttributeName("ct-outline")]
        public bool IsOutlineButton { get; set; } = false;

        /// <summary>
        /// Auto ajax animation for button. Default is true
        /// </summary>
        [HtmlAttributeName("ct-ajax-anim")]
        public bool AjaxAnimation { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (ButtonType != 0) // 0 = Enum default = No button type selected = It is a normal (non-bootstrap button)
            {
                var hasIcon = ButtonIconNameType != 0; // 0 = Enum default = No icon
                if (IsOutlineButton) // Outline buttons can't have icon (with current settings of jasny bs plugin)
                    hasIcon = false;
                var iconClass = hasIcon ? "btn-labeled" : string.Empty;

                var buttonType = Enum.GetName(typeof(BootstrapButtonType), ButtonType).ToLower();
                var buttonTypeClass = !IsOutlineButton ? $"btn-{buttonType}" : $"btn-outline-{buttonType}";

                var buttonSizeClass = string.Empty;
                switch (ButtonSizeType)
                {
                    case BootstrapButtonSizeType.Small:
                        buttonSizeClass = "btn-sm";
                        break;
                    case BootstrapButtonSizeType.Large:
                        buttonSizeClass = "btn-lg";
                        break;
                }

                var existedClasses = output.Attributes.FirstOrDefault(a => a.Name == "class")?.Value;
                var activeClass = IsActive ? "active" : string.Empty;
                var englishClass = IsEnglishContent ? (hasIcon ? "btn-en" : "btn-en-no-icon") : string.Empty;
                var directionClass = IconDirectionType == ButtonIconDirectionType.Left ? "btn-icon-left" : string.Empty;
                var fullBlockClass = HasBtnBlockClass ? "btn-block" : string.Empty;
                var ajaxAnimationClass = AjaxAnimation ? "btn-animation" : string.Empty;
                var generatedClass = $"btn {iconClass} {buttonTypeClass} {buttonSizeClass} {activeClass} " +
                                     $"{fullBlockClass} {directionClass} {englishClass} {ajaxAnimationClass} " +
                                     $"{existedClasses}";
                generatedClass = generatedClass.Trim().ReplaceMultiSpacesWithSingleSpace();

                output.Attributes.SetAttribute("class", generatedClass);

                if (IsOutlineButton) return; // Outline button has no icon, nor spinner icon

                var span = new TagBuilder("span");
                var spanClass = IconDirectionType == ButtonIconDirectionType.Left
                    ? "btn-label" : "btn-label btn-label-right";

                const string spinnerWrapperInNoIconButton = "no-icon-spinner-wrapper";
                span.AddCssClass(hasIcon ? spanClass : IconDirectionType == ButtonIconDirectionType.Right 
                    ? $"margin-left-2 {spinnerWrapperInNoIconButton}" : $"margin-right-2 {spinnerWrapperInNoIconButton}");

                var iconTagHelper = new IconTagHelper(_hostingEnvironment);
                if (hasIcon)
                {
                    var i = new TagBuilder("i");
                    i.AddCssClass("faicon btn-main-icon");
                    var svgHtml = iconTagHelper.CreateSvgContent(ButtonIconType, ButtonIconNameType, Color.White, "17px", "17px");
                    i.InnerHtml.AppendHtml(svgHtml);
                    span.InnerHtml.AppendHtml(i);
                }

                var iSpinner = new TagBuilder("i");
                iSpinner.AddCssClass("faicon btn-spinner-icon");
                var spinnerSvgHtml = iconTagHelper.CreateSvgContent(ButtonIconType, IconNameType.spinner, Color.White,
                    "17px", "17px");
                iSpinner.InnerHtml.AppendHtml(spinnerSvgHtml);
                iSpinner.AddCssClass("d-none"); //bs4=display:none                
                span.InnerHtml.AppendHtml(iSpinner);

                output.PreContent.AppendHtml(span);
            }
        }


    }
}
