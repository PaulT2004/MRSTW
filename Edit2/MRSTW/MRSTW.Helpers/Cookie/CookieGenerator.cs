using MRSTW.Helpers.Hash;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MRSTW.Helpers.Cookie
{
     public static class CookieGenerator
     {
          public static HttpCookie GenerateAuthCookie(string username)
          {
               string salt = GenerateSalt(16);
               string value = $"{username}:{salt}";
               string hashedValue = new HashGenerator().HashPassword(value);

               var cookie = new HttpCookie("AuthCookie", hashedValue)
               {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddMinutes(60)
               };

               var saltCookie = new HttpCookie("AuthSalt", salt)
               {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddMinutes(60)
               };

               HttpContext.Current.Response.Cookies.Add(cookie);
               HttpContext.Current.Response.Cookies.Add(saltCookie);

               return cookie;
          }

          public static string GenerateSalt(int length)
          {
               using (var random = new RNGCryptoServiceProvider())
               {
                    var saltBytes = new byte[length];
                    random.GetBytes(saltBytes);
                    return Convert.ToBase64String(saltBytes);
               }
          }

     }
}