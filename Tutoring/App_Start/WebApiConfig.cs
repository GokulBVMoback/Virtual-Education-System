using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Tutoring.App_Start
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }



        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
         //   config.MapHttpAttributeRoutes();


            // TODO: Add any additional configuration code.

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            //     config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: WebApiConfig.UrlPrefix + "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
       name: "DefaultApi",
       routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{action}/{id}",
       defaults: new { id = RouteParameter.Optional }
   );

          //  config.Routes.MapHttpRoute(
          //    name: "DefaultApi",
          //    routeTemplate: "api/{controller}/{action}/{id}",
          //    defaults: new { id = RouteParameter.Optional }
          //);

            //routes.MapHttpRoute("DefaultApiWithId", "Api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
            //routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");
            //routes.MapHttpRoute("DefaultApiGet", "Api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            //routes.MapHttpRoute("DefaultApiPost", "Api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });




            //        config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("text/html"));

            //        // WebAPI when dealing with JSON & JavaScript!
            //        // Setup json serialization to serialize classes to camel (std. Json format)
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver =
            new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}