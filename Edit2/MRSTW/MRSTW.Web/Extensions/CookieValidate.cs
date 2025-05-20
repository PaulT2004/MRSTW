using MRSTW.BusinessLogic;
using MRSTW.Domain.Entities.User;
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
                    string hashed = HashValue(raw);

                    if (hashed == authCookie.Value)
                         return user;
               }

               return null;
          }

          private static string HashValue(string input)
          {
               using (var sha = SHA256.Create())
               {
                    var bytes = Encoding.UTF8.GetBytes(input);
                    var hash = sha.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
               }
          }
     }
}