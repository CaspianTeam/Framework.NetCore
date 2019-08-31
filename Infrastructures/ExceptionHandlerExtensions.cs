using CaspianTeam.Framework.NetCore.Enums.Frameworks.BaseController.AjaxForm.Alert;
using CaspianTeam.Framework.NetCore.Extensions;
using CaspianTeam.Framework.NetCore.Models.Frameworks.BaseController.AjaxForm.Alert;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Web;

namespace CaspianTeam.Framework.NetCore.Infrastructures
{
    public static class ExceptionHandlerExtensions
    {
        public static HttpContext CustomExceptionHandler(this HttpContext httpContext)
        {
            var error = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                var exception = error.Error;
                var message = exception.Message;

                if (exception is SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 547:
                            message = "اطلاعات مرتبط در دیتابیس موجود می‌باشد";
                            break;
                    }
                }

                if (httpContext.Request.IsAjaxRequest())
                {
                    httpContext.Response.Headers.Add("ExceptionHandler-Message", JsonConvert.SerializeObject(
                        new AlertDialogModel
                        {
                            MessageTitle = HttpUtility.UrlEncode("خطای غیر منتظره!"),
                            MessageText = HttpUtility.UrlEncode(message),
                            MessageType = MessageType.Error,
                            BackgroundDismiss = true
                        }));
                }
                else
                {
                    httpContext.Response.Redirect("/Error?message=" + message);
                }
            }

            return httpContext;
        }
    }
}
