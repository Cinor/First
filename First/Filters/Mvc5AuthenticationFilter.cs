using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace First.Filters
{

    /// <summary>
    /// Action Filters 登入驗證實作
    /// </summary>
    public class Mvc5Authv1Attribute : ActionFilterAttribute, IAuthenticationFilter
    {

        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            //throw new NotImplementedException();
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }

    public class Mvc5Authv2Attribute : ActionFilterAttribute, IAuthenticationFilter
    {
        
        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.Principal = new GenericPrincipal(filterContext.HttpContext.User.Identity, new[] { "Admin" });
            //throw new NotImplementedException();
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}