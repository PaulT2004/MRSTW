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
               add.EventTypes {"Concerte", "Evenimente culturale", "Evenimente sportive", "Intruniri/Meeting-uri", "Actiuni de voluntariat", "Altele"};
               add.Images {"Images/music.png", "Images/cultural.png", "Images/sports.png", "Images/meeting.png", "Images/voluntary.png", "Images/other.png"}

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
