using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;

namespace WebApplication26.Controllers
{
    public class userAuth : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //var CurrentUserIDSession = HttpContext.Session.GetString("name");
          
            //var check = Session["name"];
            //if (string.IsNullOrEmpty(check))
            //{

                //    filterContext.Result = new HttpUnauthorizedResult();
                //}
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if ((filterContext.Result == null) || (filterContext.Result is HttpUnauthorizedResult))
            {
                filterContext.Result = new System.Web.Mvc.ViewResult { ViewName = "Error" };
            }
        }
    }



}
