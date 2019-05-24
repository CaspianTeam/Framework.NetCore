using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace CaspianTeam.Framework.NetCore.Extensions
{
    public static class StringExtensions
    {
        // **** اکستنشن‌های جدید را به آخر این فایل اضافه کنید
        // **** لطفا اکستنشن جدید را در ویکی ثبت نمایید


        /// <summary>
        /// گرفتن رشته‌ی بین دو رشته در یک رشته خاص
        /// </summary>
        /// <param name="value"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string GetBetweenOf(this string value, string str1, string str2)
        {
            int str1BeginIndex = value.IndexOf(str1, StringComparison.Ordinal);
            int str2BeginIndex = value.LastIndexOf(str2, StringComparison.Ordinal);
            if (str1BeginIndex == -1)
                return null;
            if (str2BeginIndex == -1)
                return null;
            int str1EndIndex = str1BeginIndex + str1.Length;
            if (str1EndIndex >= str2BeginIndex)
                return null;
            return value.Substring(str1EndIndex, str2BeginIndex - str1EndIndex);
        }

        /// <summary>
        /// گرفته رشته‌های پس از یک رشته خاص در یک رشته
        /// </summary>
        /// <param name="value"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetAfterOf(this string value, string str)
        {
            int strBeginIndex = value.LastIndexOf(str, StringComparison.Ordinal);
            if (strBeginIndex == -1)
                return null;
            int strEndIndex = strBeginIndex + str.Length;
            if (strBeginIndex >= value.Length)
                return null;
            return value.Substring(strEndIndex);
        }

        /// <summary>
        /// گرفتن رشته قبل از یک رشته خاص
        /// </summary>
        /// <param name="value"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetBeforeOf(this string value, string str)
        {
            int strBeginIndex = value.IndexOf(str, StringComparison.Ordinal);
            if (strBeginIndex == -1)
                return null;
            return value.Substring(0, strBeginIndex);
        }

        /// <summary>
        /// جدا کردن سه رقم سه رقم عدد برای مقادیر پول ایران
        /// </summary>
        /// <param name="strPrice"></param>
        /// <returns></returns>
        public static string ToRialFormat(this string strPrice)
        {
            return strPrice.Replace(",", "").ConvertToInt().ToString("n0");
        }

        /// <summary>
        /// تبدیل رشته رقم جدا شده (با کاما) به عدد
        /// </summary>
        /// <param name="strPrice"></param>
        /// <returns></returns>
        public static string RemoveRialFormat(this string strPrice)
        {
            return strPrice.Replace(",", "");
        }

        /// <summary>
        /// Convert english digits (like 123) to persian digit (like ۱۲۳)
        /// </summary>
        /// <param name="enStr"></param>
        /// <returns></returns>
        public static string ToFaDigit (this string enStr)
        {
            for (int i = 48; i < 58; i++)
            {
                enStr = enStr.Replace(Convert.ToChar(i), Convert.ToChar(1728 + i));
            }
            return enStr;
        }

        [DebuggerStepThrough]
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s) && string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// بررسی صحت کد ملی
        /// </summary>
        /// <param name="nationalCode"></param>
        /// <returns></returns>
        public static bool IsValidNationalCode(this string nationalCode)
        {
            //در صورتی که کد ملی وارد شده تهی باشد
            if (string.IsNullOrEmpty(nationalCode))
                throw new ArgumentNullException(nameof(nationalCode));


            // input has 10 digits that all of them are not equal
            if (!Regex.IsMatch(nationalCode, @"^(?!(\d)\1{9})\d{10}$"))
                return false;

            var check = Convert.ToInt32(nationalCode.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                          .Select(x => Convert.ToInt32(nationalCode.Substring(x, 1)) * (10 - x))
                          .Sum() % 11;

            bool isValid = sum < 2 && check == sum || sum >= 2 && check + sum == 11;

            return isValid;
        }

        /// <summary>
        /// بررسی صحت شناسه ملی - اشخاص حقوقی
        /// </summary>
        /// <param name="nationalId"></param>
        /// http://www.aliarash.com/article/shenasameli/shenasa_meli.htm
        /// <returns></returns>
        public static bool IsValidNationalId(this string nationalId)
        {
            //در صورتی که شناسه ملی وارد شده تهی باشد

            if (string.IsNullOrEmpty(nationalId))
                throw new ArgumentNullException(nameof(nationalId));

            nationalId = nationalId.PadLeft(11, '0');
            if (!Regex.IsMatch(nationalId, @"^\d{11}$"))
                return false;
            if (nationalId.Length > 11) return false;

            //جدا کردن رقم کنترلی
            var c = nationalId.Substring(nationalId.Length - 1, 1).ConvertToInt();
            //جدا کردن رقم دهگان
            var d = nationalId.Substring(nationalId.Length - 2, 1).ConvertToInt() + 2;

            var z = new[] { 29, 27, 23, 19, 17, 29, 27, 23, 19, 17 };
            var s = 0;
            for (var i = 0; i < 10; i++)
                s += (d + nationalId[i].ConvertToInt()) * z[i];
            s = s % 11;
            if (s == 10) s = 0;
            var isValid = c == s;

            return isValid;
        }

        /// <summary>
        /// Replace multi spaces with single space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceMultiSpacesWithSingleSpace(this string str)
        {
            return Regex.Replace(str, @"\s+", " ");
        }

    }
}
