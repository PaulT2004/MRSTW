using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MRSTW.Web.Models;

namespace MRSTW.Web.Controllers
{
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
               Events add = new Events();
               add.Username = "User"; // Correct string assignment
               add.Events = new List<string> // Proper collection initialization
               {
                    "Event 1", "Event 2", "Event 3", "Event 4", "Event 5", "Event 6"
               };

               return View(add);
          }


          public ActionResult EventType()
          {
               var eventType = Request.QueryString["e"];

               UserData add = new UserData();
               add.SingleEvent = eventType;

               return View(add);
          }

          [HttpPost]
          public ActionResult EventType(string btn)
          {
               return RedirectToAction("EventType", "Home", new { @e = btn });
          }

     }
}
