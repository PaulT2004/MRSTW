using Microsoft.AspNetCore.Mvc;
using MRSTW.Web.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MRSTW.Web.Controllers
{
     public class AuthController : Controller
     {
          private readonly IAuth _auth;
          public AuthController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _auth = bl.GetAuth();
          }

          // GetAuth
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]

          public ActionResult Auth(AuthUserDataLogin login)
          {
               var data = new UserLoginData
               {
                    Username = login.Username,
                    Password = login.Password,
               };

               string token = _auth.UserAuthLogin(data);

               return View();
          }
     }
}
