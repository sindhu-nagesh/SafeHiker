using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace SafeHikerService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SafeHikerHikeApi",
                routeTemplate: "SafeHiker/Hikes/{userEmail}/{hikeStatus}",
                defaults: new { controller = "Hikes", type = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SafeHikerUserApi",
                routeTemplate: "SafeHiker/User/{userEmail}",
                defaults: new { controller = "User" }
            );
        }
    }
}