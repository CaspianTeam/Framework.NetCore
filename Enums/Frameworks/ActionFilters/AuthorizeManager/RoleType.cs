using System.ComponentModel.DataAnnotations;

namespace CaspianTeam.Framework.NetCore.Enums.Frameworks.ActionFilters.AuthorizeManager
{
    public enum RoleType
    {
        [Display(Name = "مدیر")] Admin,

        [Display(Name = "کاربر")] Member 
    }
}