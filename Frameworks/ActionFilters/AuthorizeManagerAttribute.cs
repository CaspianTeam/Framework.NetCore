using System;
using System.Collections.Generic;
using System.Linq;
using CaspianTeam.Framework.NetCore.Enums.Frameworks.ActionFilters.AuthorizeManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace CaspianTeam.Framework.NetCore.Frameworks.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeManagerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly List<RoleType> _roleTypes;
        private readonly List<long> _accessId;

        public AuthorizeManagerAttribute(
            RoleType[] roleTypes = null,
            long[] accessId = null)
        {
            _roleTypes = roleTypes?.ToList();
            _accessId = accessId?.ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                var route = context.HttpContext.GetRouteData();
                if (route.Values["area"]?.ToString() != "Account" && route.Values["controller"]?.ToString() != "Home" &&
                    route.Values["action"]?.ToString() != "SignIn")
                {
                    context.HttpContext.Response.Redirect("/Account/Home/SignIn?ReturnUrl=" +
                                                          context.HttpContext.Request.Path +
                                                          context.HttpContext.Request.QueryString);

                }
                return;
            }

            if (_roleTypes != null)
            {
                if (user.Identity.Name.ToLower() != "admin")
                {
                    if (!_roleTypes.Any(item => user.IsInRole(item.ToString())))
                    {
                        context.HttpContext.Response.Redirect("/Account/Home/AccessDenied?ReturnUrl=" +
                                                              context.HttpContext.Request.Path +
                                                              context.HttpContext.Request.QueryString);
                        return;
                    }
                }
            }

            if (_accessId != null)
            {
                if (user.Identity.Name.ToLower() != "admin")
                {
                    //todo: برای اضافه کردن RoleClaim
                    //var roleManagerService = context.HttpContext.RequestServices.GetService<IRoleManagerService>();
                    var accessId = _accessId.Select(x => x.ToString()).ToList();
                    var claims = user.Claims.ToList();
                    if (!claims.Any(item => accessId.Contains(item.Value)))
                    {
                        context.HttpContext.Response.Redirect("/Account/Home/AccessDenied?ReturnUrl=" +
                                                              context.HttpContext.Request.Path +
                                                              context.HttpContext.Request.QueryString);
                        return;
                    }
                }
            }

        }
    }
}
