using MRSTW.Web.Models.Auth; 
using MRSTW.Domain.Entities.User;
using MRSTW.BusinessLogic;
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
          private readonly UserApi _userService;

          public AuthController()
          {
               _userService = new UserApi();
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
                    return View("Login", model);

               string hashedPassword = HashPassword(model.Password);
               var user = _userService.GetUserByCredentials(model.Username, hashedPassword);

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
                    return View(model);

               if (_userService.UserExists(model.Username, model.Email))
               {
                    ModelState.AddModelError("", "Username or Email already taken.");
                    return View(model);
               }

               string hashedPassword = HashPassword(model.Password);

               var newUser = new UserDBTable
               {
                    Username = model.Username,
                    Email = model.Email,
                    Password = hashedPassword,
                    LastLogin = DateTime.Now,
                    LastIp = Request.UserHostAddress,
               };

               _userService.CreateUser(newUser);
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
                    var cookie = new HttpCookie("AuthCookie")
                    {
                         Expires = DateTime.Now.AddDays(-1)
                    };
                    Response.Cookies.Add(cookie);
               }

               return RedirectToAction("Index", "Auth");
          }

          private string HashPassword(string password)
          {
               using (var sha = SHA256.Create())
               {
                    var bytes = Encoding.UTF8.GetBytes(password);
                    var hash = sha.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
               }
          }
     }
}
