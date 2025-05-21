using MRSTW.BusinessLogic;
using MRSTW.Domain.Entities.User;
using MRSTW.Helpers.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MRSTW.Web.Extensions
{
     public class CookieValidate
     {
          public static UserDBTable GetUserByCookie(HttpRequestBase request)
          {
               var authCookie = request.Cookies["AuthCookie"];
               var saltCookie = request.Cookies["AuthSalt"];

               if (authCookie == null || saltCookie == null)
                    return null;

               var allUsers = new UserApi().GetAllUsers();
               foreach (var user in allUsers)
               {
                    string raw = $"{user.Username}:{saltCookie.Value}";
                    string hashed = new HashGenerator().HashPassword(raw);

                    if (hashed == authCookie.Value)
                         return user;
               }

               return null;
          }
     }
}