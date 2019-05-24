using System.ComponentModel.DataAnnotations;

// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace CaspianTeam.Framework.NetCore.Enums.Locations
{
    /// <summary>
    /// این مقادیر ثابت میباشند و هر گونه تغییر در آن موجب اختلال در دیتابیس میشود
    /// </summary>
    public enum FixProvinceType
    {
        [Display(Name = "مازندران", Order = (int)FixCountryType.Iran)]
        Mazandaran = 11,

        [Display(Name = "گیلان", Order = (int)FixCountryType.Iran)]
        Gilan = 13,

        [Display(Name = "گلستان", Order = (int)FixCountryType.Iran)]
        Golestan = 17,

        [Display(Name = "تهران", Order = (int)FixCountryType.Iran)]
        Tehran = 21,

        [Display(Name = "البرز", Order = (int)FixCountryType.Iran)]
        Alborz = 26,

        [Display(Name = "قم", Order = (int)FixCountryType.Iran)]
        Ghom = 25,

        [Display(Name = "مرکزی", Order = (int)FixCountryType.Iran)]
        Markazi = 86,

        [Display(Name = "زنجان", Order = (int)FixCountryType.Iran)]
        Zanjan = 24,

        [Display(Name = "سمنان", Order = (int)FixCountryType.Iran)]
        Semnan = 23,

        [Display(Name = "همدان", Order = (int)FixCountryType.Iran)]
        Hamedan = 81,

        [Display(Name = "قزوین", Order = (int)FixCountryType.Iran)]
        Ghazvin = 28,

        [Display(Name = "اصفهان", Order = (int)FixCountryType.Iran)]
        Esfahan = 31,

        [Display(Name = "آذربایجان غربی", Order = (int)FixCountryType.Iran)]
        AzarbayejanGharbi = 44,

        [Display(Name = "کهگیلویه و بویراحمد", Order = (int)FixCountryType.Iran)]
        KohkiloyeVaBoyerAhmad = 74,

        [Display(Name = "کرمانشاه", Order = (int)FixCountryType.Iran)]
        Kermanshah = 83,

        [Display(Name = "خراسان رضوی", Order = (int)FixCountryType.Iran)]
        KhorasanRazavi = 51,

        [Display(Name = "اردبیل", Order = (int)FixCountryType.Iran)]
        Ardebil = 45,

        [Display(Name = "آذربایجان شرقی", Order = (int)FixCountryType.Iran)]
        AzarbayejanSharghi = 41,

        [Display(Name = "سیستان و بلوچستان", Order = (int)FixCountryType.Iran)]
        CistanVaBalochestan = 54,

        [Display(Name = "کردستان", Order = (int)FixCountryType.Iran)]
        Kordestan = 87,

        [Display(Name = "فارس", Order = (int)FixCountryType.Iran)]
        Phars = 71,

        [Display(Name = "لرستان", Order = (int)FixCountryType.Iran)]
        Lorestan = 66,

        [Display(Name = "کرمان", Order = (int)FixCountryType.Iran)]
        Kerman = 34,

        [Display(Name = "خراسان جنوبی", Order = (int)FixCountryType.Iran)]
        KhorasanJonobi = 56,

        [Display(Name = "بوشهر", Order = (int)FixCountryType.Iran)]
        Boshehr = 77,

        [Display(Name = "هرمزگان", Order = (int)FixCountryType.Iran)]
        Hormozgan = 76,

        [Display(Name = "خوزستان", Order = (int)FixCountryType.Iran)]
        Khozestan = 61,

        [Display(Name = "چهار محال و بختیاری", Order = (int)FixCountryType.Iran)]
        CharmahalVaBakhtiarye = 38,

        [Display(Name = "خراسان شمالی", Order = (int)FixCountryType.Iran)]
        KhorasanShomali = 58,

        [Display(Name = "یزد", Order = (int)FixCountryType.Iran)]
        Yazd = 35,

        [Display(Name = "ایلام", Order = (int)FixCountryType.Iran)]
        Ilam = 84
    }
}
