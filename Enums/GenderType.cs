﻿using System.ComponentModel.DataAnnotations;

namespace CaspianTeam.Framework.NetCore.Enums
{
    public enum GenderType
    {
        [Display(Name = "مرد")] Male=1,

        [Display(Name = "زن")] Female=2
    }
}