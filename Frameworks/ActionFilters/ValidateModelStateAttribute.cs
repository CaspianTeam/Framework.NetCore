using System;
using System.Threading.Tasks;
using CaspianTeam.Framework.NetCore.Extensions;
using CaspianTeam.Framework.NetCore.Frameworks.BaseControllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CaspianTeam.Framework.NetCore.Frameworks.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// لیست فیلدهایی که نیاز به اعتبار سنجی آنها نیست
        /// جدا کننده علامت ویرگول است
        /// </summary>
        public string IgnoreValidateFileds { get; set; }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelState = context.ModelState;
            if (!string.IsNullOrEmpty(IgnoreValidateFileds))
            {
                var fileds = IgnoreValidateFileds.Split(",");
                foreach (var filed in fileds)
                    if (modelState.ContainsKey(filed))
                        modelState.Remove(filed);
            }

            if (!modelState.IsValid)
            {
                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    context.Result = new BaseController().AjaxFormModelState(modelState);
                }
                else
                {
                    //todo: Retern View(model) برای غیر اجکسی
                }
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
