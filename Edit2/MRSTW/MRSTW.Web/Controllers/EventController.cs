using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
    public class EventController : Controller
    {
          public ActionResult Recents()
          {
               return View();
          }

          public ActionResult Concerts()
          {
               return View();
          }

          public ActionResult Fairs()
          {
               return View();
          }

          public ActionResult Sports()
          {
               return View();
          }

          public ActionResult Meetings()
          {
               return View();
          }

          public ActionResult Voluntary()
          {
               return View();
          }

          public ActionResult Others()
          {
               return View();
          }

          public ActionResult AddEvent()
          {
               return View();
          }
     }
}