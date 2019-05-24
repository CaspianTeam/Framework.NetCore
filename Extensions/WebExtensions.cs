using System;
using Microsoft.AspNetCore.Http;

namespace CaspianTeam.Framework.NetCore.Extensions
{
    public static class WebExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Headers != null)
            {
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }

            return false;
        }

    }
}
