using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace tryCCC
{
    public static class WebApiConfig
    {
        public static SqlConnection BaseConnection;

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            BaseConnection = new SqlConnection(@"Server=tcp:tryccc.database.windows.net,1433;Initial Catalog=tryCCC;Persist Security Info=False;User ID=tentents;Password=BooB8008;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            BaseConnection.Open();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
