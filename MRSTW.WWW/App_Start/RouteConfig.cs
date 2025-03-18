namespace MRSTW.WWW.App_Start
{
     public class RouteConfig
     {
          routes.IgnoreRoute{};

          routes.MapRoute(
               name: "",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

          );
     }
}
