using MRSTW.BusinessLogic.Interfaces;
using MRSTW.Domain.Entities.User;
using MRSTW.Helpers.Hash;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.BusinessLogic.AuthBL
{
     public class AuthBL : IAuth
     {
          private readonly HashGenerator _hashGenerator = new HashGenerator();

          public UserDBTable Login(string username, string password, string ip)
          {
               string hashedPassword = _hashGenerator.HashPassword(password);

               using (var db = new UserDBContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
                    if (user != null)
                    {
                         user.LastLogin = DateTime.Now;
                         user.LastIp = ip;
                         db.SaveChanges();
                    }
                    return user;
               }
          }

          public bool Register(string username, string email, string password, string ip)
          {
               using (var db = new UserDBContext())
               {
                    bool exists = db.Users.Any(u => u.Username == username || u.Email == email);
                    if (exists)
                         return false;

                    string hashedPassword = _hashGenerator.HashPassword(password);

                    var user = new UserDBTable
                    {
                         Username = username,
                         Email = email,
                         Password = hashedPassword,
                         LastLogin = DateTime.Now,
                         LastIp = ip,
                         Role = UserLevel.User
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
               }
          }
     }
}
