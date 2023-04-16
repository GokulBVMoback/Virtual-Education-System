using DAL.MasterEntity;
using Microsoft.AspNet.SignalR;
using MVC5FullCalandarPlugin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Tutoring.App_Start;

namespace Tutoring
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // AreaRegistration.RegisterAllAreas();

            // // Manually installed WebAPI 2.2 after making an MVC project.
            // GlobalConfiguration.Configure(WebApiConfig.Register); // NEW way
            ////WebApiConfig.Register(GlobalConfiguration.Configuration); // DEPRECATED


            // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // RouteConfig.RegisterRoutes(RouteTable.Routes);
            // BundleConfig.RegisterBundles(BundleTable.Bundles);
            // GlobalFilters.Filters.Add(new RequireHttpsAttribute());


            Database.SetInitializer<MyDbContext>(null);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }


        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiRequest())
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        private bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(WebApiConfig.UrlPrefixRelative);
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 6000;         
        }
    }
}
