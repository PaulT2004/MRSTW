using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MRSTW.WWW.Models;

namespace MRSTW.WWW.Controllers
{
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
               Events add = new Events();
               add.Evenimente {"Concerte", "Eve","","","",""}


               return View();
          }

     }
}
