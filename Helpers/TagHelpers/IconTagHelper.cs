using System.Drawing;
using System.IO;
using CaspianTeam.Framework.NetCore.Enums.Helpers.TagHelpers.Icon;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CaspianTeam.Framework.NetCore.Helpers.TagHelpers
{
    [HtmlTargetElement("icon")]
    public class IconTagHelper : TagHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public IconTagHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Fa Icon Type = solid/regular/light/brand
        /// </summary>
        [HtmlAttributeName("ct-type")]
        public IconType IconType { get; set; } = IconType.light;

        /// <summary>
        /// Fa Icon Name, e.g. user
        /// </summary>
        [HtmlAttributeName("ct-name")]
        public IconNameType IconNameType { get; set; }

        /// <summary>
        /// Svg Class Name
        /// </summary>
        [HtmlAttributeName("ct-class")]
        public string IconClass { get; set; }
        
        /// <summary>
        /// Svg Width, e.g. 15px
        /// </summary>
        [HtmlAttributeName("ct-width")]
        public string IconWidth { get; set; }

        /// <summary>
        /// Svg Height, e.g. 15px
        /// </summary>
        [HtmlAttributeName("ct-height")]
        public string IconHeight { get; set; }

        /// <summary>
        /// Svg Color, e.g. red
        /// </summary>
        [HtmlAttributeName("ct-color")]
        public Color IconColor { get; set; }

        /// <summary>
        /// Svg Vertical Align, e.g. -4px
        /// </summary>
        [HtmlAttributeName("ct-vertical-align")]
        public string IconVerticalAlign { get; set; }

        /// <summary>
        /// Flip Icon. Default is false
        /// </summary>
        [HtmlAttributeName("ct-flip")]
        public bool IconFlip { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "i";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "faicon");           
           
            output.Content.AppendHtml(CreateSvgContent(IconType, IconNameType, IconColor, IconWidth, IconHeight));
        }

        public string CreateSvgContent(IconType iconType, IconNameType iconNameType, Color iconColor, string iconWidth, string iconHeight)
        {
            string wwwrootPath = _hostingEnvironment.WebRootPath;
            var svgPath = Path.Combine(wwwrootPath, $@"svgfaicons\{iconType.ToString().ToLower()}\{iconNameType.ToString().ToLower().Replace("_", "-")}.svg");
            var svgContent = new HtmlDocument();
            svgContent.Load(svgPath);
            var svgNode = svgContent.DocumentNode.SelectSingleNode("//svg");
            string svgStyle = string.Empty;
            if (!iconColor.IsEmpty)
            {
                string color;

                if (iconColor.IsNamedColor && iconColor.IsKnownColor) // like Red
                    color = iconColor.Name;
                else if (iconColor.IsNamedColor && !iconColor.IsKnownColor) // Hex
                    color = $"#{iconColor.Name}";
                else
                    color = $"rgb({iconColor.R}, {iconColor.G}, {iconColor.B})"; // RGB

                svgStyle += $"fill: {color}; ";

            }
            if (!string.IsNullOrWhiteSpace(iconWidth))
            {
                if (!iconWidth.EndsWith("px") && !iconWidth.EndsWith("em")) //15 => 15px
                    iconWidth += "px";
                svgStyle += $"width: {iconWidth}; ";
            }

            if (!string.IsNullOrWhiteSpace(iconHeight))
            {
                if (!iconHeight.EndsWith("px") && !iconHeight.EndsWith("em")) //15 => 15px
                    iconHeight += "px";
                svgStyle += $"height: {iconHeight}; ";
            }

            if (!string.IsNullOrWhiteSpace(IconVerticalAlign))
            {
                if (!IconVerticalAlign.EndsWith("px") && !IconHeight.EndsWith("em"))
                    IconVerticalAlign += "px";
                svgStyle += $"vertical-align: {IconVerticalAlign}; ";
            }

            if (IconFlip)
                svgStyle += $"transform: scaleX(-1);";

            svgNode.Attributes.Add("style", svgStyle);
            if (!string.IsNullOrWhiteSpace(IconClass))
                svgNode.AddClass(IconClass);

            return svgNode.OuterHtml;
        }        
    }
}
