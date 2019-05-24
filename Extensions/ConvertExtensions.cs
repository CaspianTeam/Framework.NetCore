using System;

namespace CaspianTeam.Framework.NetCore.Extensions
{
    // **** اکستنشن‌های جدید را به آخر این فایل اضافه کنید
    // **** لطفا اکستنشن جدید را در ویکی ثبت نمایید

    public static class ConvertExtensions
    {
        /// <summary>
        /// تبدیل رشته مقدار عددی
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ConvertToInt(this string val)
        {
            return Convert.ToInt32(val);
        }
        public static int ConvertToInt(this char val)
        {
            return Convert.ToInt32(val);
        }

        public static long ConvertToLong(this string val)
        {
            return Convert.ToInt64(val);
        }

        /// <summary>
        /// تبدیل کارکترهای عربی ک و ی به فارسی
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertArabicCharsToPersian(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
                return str.Replace("ي", "ی").Replace("ك", "ک");
            return str;
        }

        /// <summary>
        /// Convert text input newlines to Html <br/> tags => to save into database.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string ConvertNewLinesToHtmlBrTags(this string inputStr)
        {
            return inputStr.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        /// <summary>
        /// Convert Html <br/> tags to Newlines command => to show string correctly into input.
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static string ConvertHtmlBrTagsToNewLines(string htmlStr)
        {
            return htmlStr.Replace("<br />", "\r\n");
        }
    }
}
