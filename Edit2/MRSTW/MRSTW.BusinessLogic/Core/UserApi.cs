using MRSTW.Helpers.Hash;
using System.Data.Entity;
using MRSTW.Domain.Entities.User;
using MRSTW.Domain;
using System.Linq;
using System.Collections.Generic;
using System;

namespace MRSTW.BusinessLogic
{
     public class UserApi
     {

          public bool UserExists(string username, string email)
          {
               using (var db = new UserDBContext())
               {
                    return db.Users.Any(u => u.Username == username || u.Email == email);
               }
          }

          public void CreateUser(UserDBTable user)
          {
               using (var db = new UserDBContext())
               {
                    db.Users.Add(user);
                    db.SaveChanges();
               }
          }

          public UserDBTable GetUserByCredentials(string username, string hashedPassword)
          {
               using (var db = new UserDBContext())
               {
                    return db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
               }
          }

          public List<UserDBTable> GetAllUsers()
          {
               using (var db = new UserDBContext())
               {
                    return db.Users.ToList();
               }
          }

          public UserDBTable ValidateUserLogin(string username, string password, string ip)
          {
               var hashGenerator = new HashGenerator();
               string hashedPassword = hashGenerator.HashPassword(password);
               var user = GetUserByCredentials(username, hashedPassword);
               if (user != null)
               {
                    user.LastLogin = DateTime.Now;
                    user.LastIp = ip;
                    using (var db = new UserDBContext())
                    {
                         db.Entry(user).State = EntityState.Modified;
                         db.SaveChanges();
                    }
               }
               return user;
          }

     }
}