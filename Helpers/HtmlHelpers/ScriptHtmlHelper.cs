using System;
using CaspianTeam.Framework.NetCore.Enums.Helpers.HtmlHelpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaspianTeam.Framework.NetCore.Helpers.HtmlHelpers
{
    public static class ScriptHtmlHelper
    {
        /// <summary>
        /// نوشتن اسکریپت به صورت دیتامیک
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="scriptType"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IHtmlContent Script<TModel>(this IHtmlHelper<TModel> htmlHelper, ScriptType scriptType, Func<object, HelperResult> template)
        {
            if(scriptType == ScriptType.Code)
                htmlHelper.ViewContext.HttpContext.Items["_script_code_" + Guid.NewGuid()] = template;

            if (scriptType == ScriptType.Link)
                htmlHelper.ViewContext.HttpContext.Items["_script_link_" + Guid.NewGuid()] = template;

            return null;
        }

        /// <summary>
        /// نمایش و تجمیع اسکریپت های دینامیک با فراخوانی این متد
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="scriptType"></param>
        /// <returns></returns>
        public static IHtmlContent RenderScripts(this IHtmlHelper htmlHelper, ScriptType scriptType)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (scriptType == ScriptType.Code)
                {
                    if (key.ToString().StartsWith("_script_code_"))
                    {
                        var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                        if (template != null)
                        {
                            htmlHelper.ViewContext.Writer.Write(template(null));
                        }
                    }
                }

                if (scriptType == ScriptType.Link)
                {
                    if (key.ToString().StartsWith("_script_link_"))
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
