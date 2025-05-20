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
               string hashedValue = HashValue(value);

               var cookie = new HttpCookie("AuthCookie", hashedValue)
               {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddHours(1)
               };

               var saltCookie = new HttpCookie("AuthSalt", salt)
               {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddHours(1)
               };

               HttpContext.Current.Response.Cookies.Add(cookie);
               HttpContext.Current.Response.Cookies.Add(saltCookie);

               return cookie;
          }

          private static string GenerateSalt(int length)
          {
               using (var random = new RNGCryptoServiceProvider())
               {
                    var saltBytes = new byte[length];
                    random.GetBytes(saltBytes);
                    return Convert.ToBase64String(saltBytes);
               }
          }

          private static string HashValue(string input)
          {
               using (var sha256 = SHA256.Create())
               {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);
                    return Convert.ToBase64String(hashBytes);
               }
          }
     }
}