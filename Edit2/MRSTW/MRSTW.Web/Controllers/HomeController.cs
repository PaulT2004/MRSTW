using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using MRSTW.Web.Models;

namespace MRSTW.Web.Controllers
{
     public class HomeController : BaseController
     {
          public ActionResult Index()
          {
               if (Session["User"] == null)
               {
                    return RedirectToAction("Index", "Auth");
               }

               ViewBag.Username = Session["User"].ToString();
               return View();
          }

          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var authCookie = HttpContext.Request.Cookies["AuthCookie"];

               if (authCookie == null || string.IsNullOrEmpty(authCookie.Value))
               {
                    filterContext.Result = RedirectToAction("Index", "Auth");
                    return;
               }

               ViewBag.Username = authCookie.Value;

               base.OnActionExecuting(filterContext);
          }

          public ActionResult FAQ()
          {
               return View();
          }

     }
}
