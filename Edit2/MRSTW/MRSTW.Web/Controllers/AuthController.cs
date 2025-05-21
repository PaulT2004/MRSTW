using MRSTW.BusinessLogic.Interfaces;
using MRSTW.Web.Models.Auth; 
using MRSTW.Domain.Entities.User;
using MRSTW.BusinessLogic.AuthBL;
using MRSTW.Helpers.Cookie;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Web;

namespace MRSTW.Web.Controllers
{
     public class AuthController : Controller
     {
          private readonly IAuth _authService;

          public AuthController()
          {
               _authService = new AuthBL();
          }

          [HttpGet]
          public ActionResult Index()
          {
               return View("Login");
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(AuthUserDataLogin model)
          {
               if (!ModelState.IsValid)
               {
                    return View("Login", model);
               }

               var user = _authService.Login(model.Username, model.Password, Request.UserHostAddress);
               if (user == null)
               {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return View("Login", model);
               }

               Session["User"] = user;
               CookieGenerator.GenerateAuthCookie(user.Username);
               return RedirectToAction("Index", "Home");
          }

          [HttpGet]
          public ActionResult Register()
          {
               return View();
          }


          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Register(AuthUserDataRegister model)
          {
               if (!ModelState.IsValid)
               {
                    return View(model);
               }

               bool success = _authService.Register(model.Username, model.Email, model.Password, Request.UserHostAddress);
               if (!success)
               {
                    ModelState.AddModelError("", "Username or Email already taken.");
                    return View(model);
               }

               return RedirectToAction("Login", "Auth");
          }

          public ActionResult Login()
          { 
               return View("Login");
          }

          public ActionResult Logout()
          {
               Session.Clear();
               if (Request.Cookies["AuthCookie"] != null)
               {
                    var cookie = new HttpCookie("AuthCookie") { Expires = DateTime.Now.AddDays(-1) };
                    Response.Cookies.Add(cookie);
               }
               return RedirectToAction("Index", "Auth");
          }

     }
}
