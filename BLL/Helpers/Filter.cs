using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BLL.Helpers
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //public class CustomAuthorize : AuthorizeAttribute
    //{
    //    public string AccessLevel { get; set; }
    //    public object Request { get; private set; }

    //    public string RedirectUrl = "~/UnAuthorizeAccess/UnAuthorizeAccess";

    //    protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
    //    {
    //        bool isAuthorized = base.AuthorizeCore(httpContext);
    //        var user = Config.User;
    //        var response = httpContext.Response;
    //        var request = httpContext.Request;
    //        var filterContext = new AuthorizationContext();
    //        if (user == null)
    //        {
    //            if (request.IsAjaxRequest())
    //            {
    //                SessionHandler(filterContext);
    //                isAuthorized = false;
    //            }
    //            else
    //            {
    //                SessionHandler(filterContext);
    //                isAuthorized = false;
    //            }
    //        }
    //        return isAuthorized;
    //    }

    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        base.OnAuthorization(filterContext);
    //        var httpContext = filterContext.HttpContext;
    //        var user = Config.User;
    //        string ReturnUrl=null;

    //        if (user != null)
    //        {
    //            var isAuthorized = true;
    //            if (Config.CurrentUser!=0 && Config.User.UserType==(int)Enumerations.UserType.Super)
    //            {
    //                ReturnUrl =

    //            }
    //            //if (!isAuthorized && filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
    //            //{
    //            //    filterContext.RequestContext.HttpContext.Response.Redirect(RedirectUrl);
    //            //}
    //        }
    //    }

    //    public void SessionHandler(AuthorizationContext filterContext)
    //    {
    //        base.HandleUnauthorizedRequest(filterContext);
    //    }



    //}


    public class a
    {

    }

}
