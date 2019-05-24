using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CaspianTeam.Framework.NetCore.Extensions
{
    public static class Extensions
    {
        // **** اکستنشن‌های جدید را به آخر این فایل اضافه کنید
        // **** لطفا اکستنشن جدید را در ویکی ثبت نمایید
        public static string GetParentName(this Type value, int level = 0)
        {
            var tempSplit = value.Namespace.Split(".");
            return tempSplit[(tempSplit.Length - 1) + level];
        }

        /// <summary>
        /// بازیابی مقادیر موجود در خصوصیات یک ابجکت خاص
        /// </summary>
        /// <param name="myObject">My object.</param>
        /// <returns>System.Object[].</returns>
        public static object[] GetObjectValues(this object myObject)
        {
            var myType = myObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            IList<object> valuesList = new List<object>();
            foreach (var prop in props)
            {
                object propValue;
                if (prop.Name.Contains("QueryData") && prop.PropertyType.IsClass)
                {
                    var queryDataType = prop.PropertyType;
                    IList<PropertyInfo> queryDataTypeProps = new List<PropertyInfo>(queryDataType.GetProperties());
                    var queryDataValue = GetPropertyValue(myObject, prop.Name);
                    foreach (var queryItem in queryDataTypeProps)
                    {
                        propValue = queryItem.GetValue(queryDataValue, null);
                        if (propValue != null)
                            valuesList.Add(propValue);
                    }
                    continue;
                }
                propValue = prop.GetValue(myObject, null);
                if (propValue != null)
                    valuesList.Add(propValue);
            }
            return valuesList.ToArray();
        }

        /// <summary>
        /// بازیابی مقدار یک خصوصیت با استفاداه از رفلکشن
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>System.Object.</returns>
        private static object GetPropertyValue(this object obj, string propertyName)
        {
            foreach (var prop in propertyName.Split('.').Select(s => obj.GetType().GetProperty(s)))
                obj = prop.GetValue(obj, null);

            return obj;
        }

        /// <summary>
        /// برای بدست آوردن کلید پارامتر های مدلی برای مموری کش
        /// </summary>
        /// <param name="myObject"></param>
        /// <returns></returns>
        public static string GetObjectValuesForMemoryCache(this object myObject)
        {
            return string.Join("_", myObject.GetObjectValues());
        }

        /// <summary>
        /// Get DisplayName value of enum item
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DisplayName(this Enum value)
        {
            return value
                .GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttributes<DisplayAttribute>()
                .First()
                .GetName();
        }

        /// <summary>
        /// Get OrderBy value of enum item
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long? GetOrderName(this Enum value)
        {
            return value
                .GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttributes<DisplayAttribute>()
                .First()
                .GetOrder();
        }
    }
}
