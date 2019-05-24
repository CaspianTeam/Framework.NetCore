using System;
using CaspianTeam.Framework.NetCore.Enums.Helpers.HtmlHelpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaspianTeam.Framework.NetCore.Helpers.HtmlHelpers
{
    public static class StyleHtmlHelper
    {
        /// <summary>
        /// نوشتن استایل به صورت دیتامیک
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="StyleType"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IHtmlContent Style<TModel>(this IHtmlHelper<TModel> htmlHelper, StyleType styleType, Func<object, HelperResult> template)
        {
            if(styleType == StyleType.Code)
                htmlHelper.ViewContext.HttpContext.Items["_style_code_" + Guid.NewGuid()] = template;

            if (styleType == StyleType.Link)
                htmlHelper.ViewContext.HttpContext.Items["_style_link_" + Guid.NewGuid()] = template;

            return null;
        }

        /// <summary>
        /// نمایش و تجمیع استایل های دینامیک با فراخوانی این متد
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="styleType"></param>
        /// <returns></returns>
        public static IHtmlContent RenderStyles(this IHtmlHelper htmlHelper, StyleType styleType)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (styleType == StyleType.Code)
                {
                    if (key.ToString().StartsWith("_style_code_"))
                    {
                        var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                        if (template != null)
                        {
                            htmlHelper.ViewContext.Writer.Write(template(null));
                        }
                    }
                }

                if (styleType == StyleType.Link)
                {
                    if (key.ToString().StartsWith("_style_link_"))
                    {
                        var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                        if (template != null)
                        {
                            htmlHelper.ViewContext.Writer.Write(template(null));
                        }
                    }
                }
            }

            return null;
        }
    }
}
