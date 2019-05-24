using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CaspianTeam.Framework.NetCore.Models.Methods;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaspianTeam.Framework.NetCore.Helpers.HtmlHelpers
{
    public static class MenuBuilderByMethodHtmlHelper
    {
        public static IHtmlContent CreateAdminMenu<TModel>(this IHtmlHelper<TModel> htmlHelper, object methodMenu, long methodMenuId)
        {
            var listMenu = GetListMenuItemByMethodType(methodMenu.GetType());
            var html = string.Empty;
            foreach (var i1 in listMenu.Where(item => item.BaseId == methodMenuId).OrderBy(o => o.Order))
            {
                var htmlChild1 = string.Empty;
                var sub1 = listMenu.Where(item => item.BaseId == i1.Id).OrderBy(o => o.Order).ToList();
                foreach (var i2 in sub1)
                {
                    var htmlChild2 = string.Empty;
                    var sub2 = listMenu.Where(item => item.BaseId == i2.Id).OrderBy(o => o.Order).ToList();
                    foreach (var i3 in sub2)
                    {
                        var url3 = string.IsNullOrEmpty(i3.Url) ? "#" : i3.Url;
                        htmlChild2 += $@"
                                        <li>
                                            <a href='{url3}'>
                                                <i class='{i3.IconClass}'></i>
                                                <span>{i3.Title}</span>
                                            </a>
                                        </li>
                                        ";
                    }
                    var tempHtmlChild2 = string.Empty;
                    var isSub2 = sub2.Count > 0;
                    if (isSub2)
                    {
                        tempHtmlChild2 = $@"
                                            <ul>
                                                {htmlChild2}
                                            </ul>
                                        ";
                    }
                    var subWithSubClass = isSub2 ? "class='sub-with-sub'" : "";
                    var url2 = string.IsNullOrEmpty(i2.Url) ? "#" : i2.Url;
                    htmlChild1 += $@"
                                    <li {subWithSubClass}>
                                        <a href='{url2}'>
                                            <i class='{i2.IconClass}'></i>
                                            <span>{i2.Title}</span>
                                        </a>
                                        {tempHtmlChild2}
                                    </li>
                                    ";
                }
                var tempHtmlChild1 = string.Empty;
                var isSub1 = sub1.Count > 0;
                if (isSub1)
                {
                    tempHtmlChild1 = $@"
                                        <div class='sub-item'>
                                            <ul>{htmlChild1}</ul>
                                        </div>
                                    ";
                }
                var withSubClass = isSub1 ? "with-sub" : "";
                var url1 = string.IsNullOrEmpty(i1.Url) ? "#" : i1.Url;
                html += $@"
                            <li class='nav-item {withSubClass}'>
                                <a class='nav-link' href='{url1}'>
                                    <i class='{i1.IconClass}'></i>
                                    <span>{i1.Title}</span>
                                </a>
                                {tempHtmlChild1}
                            </li>
                            ";
            }

            return new HtmlString(html);
        }

        private static List<MenuItemModel> GetListMenuItemByMethodType(Type methodMenuType)
        {
            var getMemberNested = methodMenuType.GetMembers().Where(item => item.MemberType == MemberTypes.NestedType).ToList();
            var listMemberNestedTemp = new List<MemberInfo>();
            var lietMenuItem = new List<MenuItemModel>();
            //برچسب برای افزودن زیرمجموعه ها
            MemberNested:
            foreach (var memberInfo in getMemberNested)
            {
                var memberInfoType = memberInfo.DeclaringType.GetNestedType(memberInfo.Name);
                var getFields = memberInfoType.GetMembers().Where(item => item.MemberType == MemberTypes.Field).ToList();

                //مقدار فیلد ها را بصورت key , value برمیگرداند
                var listFilds = getFields.Select(s => new
                {
                    Key = s.Name,
                    Value = ((FieldInfo) s).GetValue(null)
                }).ToList();

                if (!((bool?) listFilds.FirstOrDefault(i => i.Key.Equals("IgnoreMenu"))?.Value ?? false))
                {
                    //مقدار ها را در لیست ادد میکند
                    lietMenuItem.Add(new MenuItemModel
                    {
                        Id = (long?) listFilds.FirstOrDefault(i => i.Key.Equals("Id"))?.Value,
                        BaseId = (long?) listFilds.FirstOrDefault(i => i.Key.Equals("BaseId"))?.Value,
                        Title = (string) listFilds.FirstOrDefault(i => i.Key.Equals("Title"))?.Value,
                        Url = (string) listFilds.FirstOrDefault(i => i.Key.Equals("Url"))?.Value,
                        IconClass = (string) listFilds.FirstOrDefault(i => i.Key.Equals("IconClass"))?.Value,
                        Order = (int?) listFilds.FirstOrDefault(i => i.Key.Equals("Order"))?.Value
                    });
                }

                //اگر زیر مجموعه داشت اضافه میکند برای GoTo
                listMemberNestedTemp.AddRange(memberInfoType.GetMembers()
                    .Where(item => item.MemberType == MemberTypes.NestedType).ToList());
            }

            // اگر زیر مجموعه ای موجود بود لیست را بر میگرداند و از برچسب دوباره شروع میکند
            if (listMemberNestedTemp.Count > 0)
            {
                getMemberNested = listMemberNestedTemp;
                listMemberNestedTemp = new List<MemberInfo>();
                goto MemberNested;
            }

            return lietMenuItem;
        }

    }
}
