using System.Collections.Generic;
using System.Globalization;
using CaspianTeam.Framework.NetCore.Enums.Culture;
using CaspianTeam.Framework.NetCore.Extensions;

namespace CaspianTeam.Framework.NetCore.Frameworks.Services.CultureService
{
    public interface ICultureService
    {
        bool IsDirRtl { get; }
        string SetClassByDir(string ltrClass, string rtlClass);
        string SetIfDirIsRtl(string str);
        string GetCulture();
        bool IsPersian();
        bool IsEnglish();
    }
    public class CultureService : ICultureService
    {
        public string GetCulture()
        {
            return CultureInfo.CurrentCulture.Name;
        }

        public bool IsEnglish()
        {
            return GetCulture() == CultureType.en_US.DisplayName();
        }

        public bool IsPersian()
        {
            return GetCulture() == CultureType.fa_IR.DisplayName();
        }


        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// Is Current Language Direction RTL (Like Persian) Or Not (Then It Is LTR)
        /// </summary>
        public bool IsDirRtl
        {
            get
            {
                var rtlCultures = new List<string> { CultureType.fa_IR.DisplayName() };
                return rtlCultures.Contains(CultureInfo.CurrentCulture.Name);
            }
        }

        /// <summary>
        /// Set Class to Html Element for Layout based on CultureService
        /// </summary>
        /// <param name="ltrClass">Class Name in Left To Right Layout, like English</param>
        /// <param name="rtlClass">Class Name in Right To Left, like Persian</param>
        /// <returns></returns>
        public string SetClassByDir(string ltrClass, string rtlClass)
        {
            return IsDirRtl ? rtlClass : ltrClass;
        }

        // ReSharper disable once InconsistentNaming
        public string SetIfDirIsRtl(string str)
        {
            return IsDirRtl ? str : string.Empty;
        }
    }
}
