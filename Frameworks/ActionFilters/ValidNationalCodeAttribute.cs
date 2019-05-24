using System.ComponentModel.DataAnnotations;
using CaspianTeam.Framework.NetCore.Extensions;

namespace CaspianTeam.Framework.NetCore.Frameworks.ActionFilters
{
    /// <summary>
    /// بررسی صحت کد ملی
    /// </summary>
    public class ValidNationalCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().IsNullOrEmpty())
                return true;

            return value.ToString().IsValidNationalCode();
        }
    }
}
