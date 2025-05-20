using System.Data.Entity;
using MRSTW.Domain.Entities.User;
using MRSTW.Domain;
using System.Linq;
using System.Collections.Generic;

namespace MRSTW.BusinessLogic
{
     public class UserApi
     {
          public bool RegisterUser(string email, string username, string password)
          {
               using (var db = new UserDBContext())
               {
                    var existingUser = db.Users.FirstOrDefault(u => u.Username == username || u.Email == email);
                    if (existingUser != null)
                         return false;

                    // REGISTER
                    var user = new UserDBTable
                    {
                         Email = email,
                         Username = username,
                         Password = password,
                         LastLogin = System.DateTime.Now,
                         LastIp = "127.0.0.1",
                         Role = UserLevel.User
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
               }
          }

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

     }
}