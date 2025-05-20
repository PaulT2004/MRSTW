using MRSTW.Web.Extensions;
using MRSTW.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
     public class BaseController : Controller
     {
          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var user = CookieValidate.GetUserByCookie(Request);
               if (user != null)
               {
                    Session["User"] = user;
                    Session["Role"] = user.Role;
                    Session["LoginStatus"] = "login";
               }
               else
               {
                    Session.Clear();
                    Session["LoginStatus"] = "logout";

                    if (Request.Cookies["AuthCookie"] != null)
                    {
                         var expiredCookie = new HttpCookie("AuthCookie")
                         {
                              Expires = DateTime.Now.AddDays(-1)
                         };
                         Response.Cookies.Add(expiredCookie);
                     }
               }

          base.OnActionExecuting(filterContext);
          }
     }
}
