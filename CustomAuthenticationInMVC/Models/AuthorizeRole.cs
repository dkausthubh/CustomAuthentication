﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomAuthenticationInMVC.Models
{
    public class AuthorizeRole
    {
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
        public class AuthorizeRoleAttribute : AuthorizeAttribute
        {
            public AuthorizeRoleAttribute(params object[] roles)
            {
                if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                    throw new ArgumentException("roles");
                this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
            }
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectResult("~/Account/Login");
                    return;
                }
                if (filterContext.Result is HttpUnauthorizedResult)
                {
                    filterContext.Result = new RedirectResult("~/Account/AccessDenied");
                    return;
                }
            }
        }
    }
}