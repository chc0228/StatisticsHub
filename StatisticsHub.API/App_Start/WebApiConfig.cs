using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace StatisticsHub.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/",
                defaults: new { id = RouteParameter.Optional }
            );

            //Enables Cross-Origin Resource Sharing
            config.EnableCors();

            //allows property on the client to be camelcase, lets turn this on since our dashboard will be in angular 2
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Enable attribute routing
            //config.MapHttpAttributeRoutes();
        }
    }
}
