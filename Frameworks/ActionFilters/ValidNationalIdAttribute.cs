using System.ComponentModel.DataAnnotations;
using CaspianTeam.Framework.NetCore.Extensions;

namespace CaspianTeam.Framework.NetCore.Frameworks.ActionFilters
{
    /// <summary>
    /// بررسی صحت شناسه ملی اشخاص حقوقی
    /// </summary>
    public class ValidNationalIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().IsNullOrEmpty())
                return true;

            return value.ToString().IsValidNationalId();
        }
    }
}
