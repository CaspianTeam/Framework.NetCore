// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

using System.ComponentModel.DataAnnotations;

namespace CaspianTeam.Framework.NetCore.Enums.Locations
{
    //-----------*** این مقادیر ثابت میباشند و هر گونه تغییر در آن موجب اختلال در دیتابیس میشود ***------------------------------
    public enum FixCityType
    {
        #region لیست شهرهای استان مازندران
        [Display(Name = "آمل", Order = (int)FixProvinceType.Mazandaran)]
        Amol = 1,
        [Display(Name = "بابل", Order = (int)FixProvinceType.Mazandaran)]
        Babol = 2,
        [Display(Name = "ساری", Order = (int)FixProvinceType.Mazandaran)]
        Sari = 3,
        [Display(Name = "قائم شهر", Order = (int)FixProvinceType.Mazandaran)]
        GhaemShahr = 4,
        [Display(Name = "بهشهر", Order = (int)FixProvinceType.Mazandaran)]
        Behshahr = 5,
        [Display(Name = "چالوس", Order = (int)FixProvinceType.Mazandaran)]
        Chaloos = 6,
        [Display(Name = "نکا", Order = (int)FixProvinceType.Mazandaran)]
        Neka = 7,
        [Display(Name = "بابلسر", Order = (int)FixProvinceType.Mazandaran)]
        Babolsar = 8,
        [Display(Name = "تنکابن", Order = (int)FixProvinceType.Mazandaran)]
        Tonekabon = 9,
        [Display(Name = "نوشهر", Order = (int)FixProvinceType.Mazandaran)]
        Noshahr = 10,
        [Display(Name = "فریدونکنار", Order = (int)FixProvinceType.Mazandaran)]
        Fereydonkenar = 11,
        [Display(Name = "رامسر", Order = (int)FixProvinceType.Mazandaran)]
        Ramsar = 12,
        [Display(Name = "جویبار", Order = (int)FixProvinceType.Mazandaran)]
        Joybar = 13,
        [Display(Name = "محمودآباد", Order = (int)FixProvinceType.Mazandaran)]
        MahmoodAbad = 14,
        [Display(Name = "امیرکلا", Order = (int)FixProvinceType.Mazandaran)]
        Amirkola = 15,
        [Display(Name = "نور", Order = (int)FixProvinceType.Mazandaran)]
        Noor = 16,
        [Display(Name = "گلوگاه", Order = (int)FixProvinceType.Mazandaran)]
        Galogah = 17,
        [Display(Name = "کتالم وسادات شهر", Order = (int)FixProvinceType.Mazandaran)]
        KatalomVaSadatshahr = 18,
        [Display(Name = "زیرآب", Order = (int)FixProvinceType.Mazandaran)]
        Zirab = 19,
        [Display(Name = "عباس آباد", Order = (int)FixProvinceType.Mazandaran)]
        AbasAbad = 20,
        [Display(Name = "کلاردشت", Order = (int)FixProvinceType.Mazandaran)]
        Kelardasht = 21,
        [Display(Name = "دابودشت", Order = (int)FixProvinceType.Mazandaran)]
        Dabodasht = 22,
        [Display(Name = "بلده", Order = (int)FixProvinceType.Mazandaran)]
        Baladah = 23,
        [Display(Name = "کلارآباد", Order = (int)FixProvinceType.Mazandaran)]
        KelarAbad = 24,
        [Display(Name = "نشتارود", Order = (int)FixProvinceType.Mazandaran)]
        Nashtarood = 25,
        [Display(Name = "رویان", Order = (int)FixProvinceType.Mazandaran)]
        Royan = 26,
        [Display(Name = "پل سفید", Order = (int)FixProvinceType.Mazandaran)]
        PolSefid = 27,
        [Display(Name = "چمستان", Order = (int)FixProvinceType.Mazandaran)]
        Chamestan = 28,
        #endregion

        #region لیست شهرهای استان گلستان
        [Display(Name = "گرگان", Order = (int)FixProvinceType.Golestan)]
        Gorgan = 29,
        [Display(Name = "گنبد کاووس", Order = (int)FixProvinceType.Golestan)]
        GonbadKavous = 30,
        [Display(Name = "بندر ترکمن", Order = (int)FixProvinceType.Golestan)]
        BandarTorkman = 31,
        [Display(Name = "علی‌آباد کتول", Order = (int)FixProvinceType.Golestan)]
        AliAbadKatol = 32,
        [Display(Name = "آزادشهر", Order = (int)FixProvinceType.Golestan)]
        AzadShahr = 33,
        [Display(Name = "کردکوی", Order = (int)FixProvinceType.Golestan)]
        Kordkoy = 34,
        [Display(Name = "کلاله", Order = (int)FixProvinceType.Golestan)]
        Kalaleh = 35,
        [Display(Name = "آق‌قلا", Order = (int)FixProvinceType.Golestan)]
        AghGhala = 36,
        [Display(Name = "مینودشت", Order = (int)FixProvinceType.Golestan)]
        MinoDasht = 37,
        [Display(Name = "گالیکش", Order = (int)FixProvinceType.Golestan)]
        Galikwsh = 38,
        [Display(Name = "اینچه‌برون", Order = (int)FixProvinceType.Golestan)]
        IncheBeron = 39,
        [Display(Name = "بندر گز", Order = (int)FixProvinceType.Golestan)]
        BandarGaz = 40,
        [Display(Name = "فاضل‌آباد", Order = (int)FixProvinceType.Golestan)]
        FazelAbad = 41,
        [Display(Name = "گمیشان", Order = (int)FixProvinceType.Golestan)]
        Gomeyshan = 42,
        [Display(Name = "سیمین‌شهر", Order = (int)FixProvinceType.Golestan)]
        SiminShahr = 43,
        [Display(Name = "رامیان", Order = (int)FixProvinceType.Golestan)]
        Ramian = 44,
        [Display(Name = "خان‌ببین", Order = (int)FixProvinceType.Golestan)]
        KhanBebin = 45,
        [Display(Name = "مراوه", Order = (int)FixProvinceType.Golestan)]
        Maraveh = 46,
        [Display(Name = "دلند", Order = (int)FixProvinceType.Golestan)]
        Deland = 47,
        [Display(Name = "نگین‌شهر", Order = (int)FixProvinceType.Golestan)]
        NeginShahr = 48,
        [Display(Name = "سرخنکلاته", Order = (int)FixProvinceType.Golestan)]
        Sarkhankalateh = 49,
        [Display(Name = "جلین", Order = (int)FixProvinceType.Golestan)]
        Jalin = 50,
        [Display(Name = "انبارآلوم", Order = (int)FixProvinceType.Golestan)]
        AnbarAlom = 51,
        [Display(Name = "نوکنده", Order = (int)FixProvinceType.Golestan)]
        Nokandeh = 52,
        [Display(Name = "فراغی", Order = (int)FixProvinceType.Golestan)]
        Feraghi = 53,
        [Display(Name = "تاتار علیا", Order = (int)FixProvinceType.Golestan)]
        TatarOulia = 54,
        [Display(Name = "سنگدوین", Order = (int)FixProvinceType.Golestan)]
        Sangdevin = 55,
        [Display(Name = "مزرعه", Order = (int)FixProvinceType.Golestan)]
        Mazraeh = 56,
        [Display(Name = "نوده خاندوز", Order = (int)FixProvinceType.Golestan)]
        NodehKhandoz = 57,
        #endregion

        #region لیست شهرهای استان تهران
        [Display(Name = "تهران", Order = (int)FixProvinceType.Tehran)]
        Tehran = 58,
        [Display(Name = "اسلام‌شهر", Order = (int)FixProvinceType.Tehran)]
        EslamShahr = 59,
        [Display(Name = "شهریار", Order = (int)FixProvinceType.Tehran)]
        Shahriayar = 60,
        [Display(Name = "قدس", Order = (int)FixProvinceType.Tehran)]
        Ghods = 61,
        [Display(Name = "ملارد", Order = (int)FixProvinceType.Tehran)]
        Malard = 62,
        [Display(Name = "گلستان", Order = (int)FixProvinceType.Tehran)]
        Golestan = 63,
        [Display(Name = "پاکدشت", Order = (int)FixProvinceType.Tehran)]
        Pakdasht = 64,
        [Display(Name = "قرچک", Order = (int)FixProvinceType.Tehran)]
        Gharchak = 65,
        [Display(Name = "ورامین", Order = (int)FixProvinceType.Tehran)]
        Varamin = 66,
        [Display(Name = "نسیم‌شهر", Order = (int)FixProvinceType.Tehran)]
        NasimShahr = 67,
        [Display(Name = "اندیشه", Order = (int)FixProvinceType.Tehran)]
        Andishe = 68,
        [Display(Name = "رباط‌کریم", Order = (int)FixProvinceType.Tehran)]
        RobatKarim = 69,
        [Display(Name = "پرند", Order = (int)FixProvinceType.Tehran)]
        Parand = 70,
        [Display(Name = "باغستان", Order = (int)FixProvinceType.Tehran)]
        Baghestan = 71,
        [Display(Name = "بومهن", Order = (int)FixProvinceType.Tehran)]
        Bomehen = 72,
        [Display(Name = "پردیس", Order = (int)FixProvinceType.Tehran)]
        Pardis = 73,
        [Display(Name = "باقرشهر", Order = (int)FixProvinceType.Tehran)]
        BagherShahr = 74,
        [Display(Name = "پیشوا", Order = (int)FixProvinceType.Tehran)]
        Pishva = 75,
        [Display(Name = "صالحیه", Order = (int)FixProvinceType.Tehran)]
        Salehieh = 76,
        [Display(Name = "صباشهر", Order = (int)FixProvinceType.Tehran)]
        Sabashahr = 77,
        [Display(Name = "چهاردانگه", Order = (int)FixProvinceType.Tehran)]
        CharDange = 78,
        [Display(Name = "دماوند", Order = (int)FixProvinceType.Tehran)]
        Damavand = 79,
        [Display(Name = "حسن‌آباد", Order = (int)FixProvinceType.Tehran)]
        HasanAbad = 80,
        [Display(Name = "وحیدیه", Order = (int)FixProvinceType.Tehran)]
        Vahidieh = 81,
        [Display(Name = "نصیرآباد", Order = (int)FixProvinceType.Tehran)]
        NasirAbad = 82,
        [Display(Name = "فردوسیه", Order = (int)FixProvinceType.Tehran)]
        Ferdosieh = 83,
        [Display(Name = "رودهن", Order = (int)FixProvinceType.Tehran)]
        Rodehen = 84,
        [Display(Name = "شاهدشهر", Order = (int)FixProvinceType.Tehran)]
        ShahedShahr = 85,
        [Display(Name = "صفادشت", Order = (int)FixProvinceType.Tehran)]
        SafaDasht = 86,
        [Display(Name = "فیروزکوه", Order = (int)FixProvinceType.Tehran)]
        Firoozkoh = 87,
        [Display(Name = "لواسان", Order = (int)FixProvinceType.Tehran)]
        Lavasan = 88,
        [Display(Name = "آبسرد", Order = (int)FixProvinceType.Tehran)]
        Absard = 89,
        [Display(Name = "شریف‌آباد", Order = (int)FixProvinceType.Tehran)]
        SharifAabad = 90,
        [Display(Name = "کهریزک", Order = (int)FixProvinceType.Tehran)]
        Kahrizak = 91,
        [Display(Name = "فشم", Order = (int)FixProvinceType.Tehran)]
        Fasham = 92,
        [Display(Name = "جوادآباد", Order = (int)FixProvinceType.Tehran)]
        JavadAbad = 93,
        [Display(Name = "کیلان", Order = (int)FixProvinceType.Tehran)]
        Kilan = 94,
        [Display(Name = "آبعلی", Order = (int)FixProvinceType.Tehran)]
        Abali = 95,
        [Display(Name = "ارجمند", Order = (int)FixProvinceType.Tehran)]
        Arjmand = 96,
        [Display(Name = "شمشک", Order = (int)FixProvinceType.Tehran)]
        Shemshak = 97,
        [Display(Name = "احمدآباد مستوفی", Order = (int)FixProvinceType.Tehran)]
        AhmadAbad = 98,
        [Display(Name = "فرون‌آباد", Order = (int)FixProvinceType.Tehran)]
        ForonAbad = 99
        #endregion
    }
}
