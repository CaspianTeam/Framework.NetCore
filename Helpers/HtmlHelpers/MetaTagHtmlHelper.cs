using System;
using System.Collections.Generic;
using CaspianTeam.Framework.NetCore.Enums.Helpers.HtmlHelpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaspianTeam.Framework.NetCore.Helpers.HtmlHelpers
{
    public static class MetaTagHtmlHelper
    {
        /// <summary>
        /// نوشتن متاتگ‌های صفحه - برای کیوردس کلمات با ویرگول انگلیسی از هم جدا شوند و توضیحات بین 100 تا 200 کارکتر باشد
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="metaTagType"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IHtmlContent MetaTag<TModel>(this IHtmlHelper<TModel> htmlHelper, MetaTagType metaTagType, string template)
        {
            if(metaTagType == MetaTagType.Description)
                htmlHelper.ViewContext.HttpContext.Items["_metaTag_description_" + Guid.NewGuid()] = template;

            if (metaTagType == MetaTagType.Keywords)
                htmlHelper.ViewContext.HttpContext.Items["_metaTag_keywords_" + Guid.NewGuid()] = template;

            return null;
        }

        /// <summary>
        /// نمایش و تجمیع متاتگ ها با فراخوانی این متد
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="metaTagType"></param>
        /// <returns></returns>
        public static List<string> RenderMetaTags(this IHtmlHelper htmlHelper, MetaTagType metaTagType)
        {
            var tempList = new List<string>();
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (metaTagType == MetaTagType.Description)
                {
                    if (key.ToString().StartsWith("_metaTag_description_"))
                    {
                        var template = htmlHelper.ViewContext.HttpContext.Items[key] as string;
                        if (!string.IsNullOrEmpty(template))
                        {
                            tempList.Add(template);
                        }
                    }
                }

                if (metaTagType == MetaTagType.Keywords)
                {
                    if (key.ToString().StartsWith("_metaTag_keywords_"))
                    {
                        var template = htmlHelper.ViewContext.HttpContext.Items[key] as string;
                        if (!string.IsNullOrEmpty(template))
                        {
                            tempList.Add(template);
                        }
                    }
                }
            }

            return tempList;
        }
    }
}
