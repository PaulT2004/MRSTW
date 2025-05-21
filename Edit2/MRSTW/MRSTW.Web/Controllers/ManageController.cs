using MRSTW.BusinessLogic;
using MRSTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
     public class ManageController : Controller
     {
          private readonly UserApi _userApi = new UserApi();
          public ActionResult ManageUsers()
          {
               List<UserDBTable> users = _userApi.GetAllUsers();
               return View(users);
          }

          [HttpPost]
          public ActionResult UpdateRoles(List<UserDBTable> users)
          {
               using (var db = new UserDBContext())
               {
                    foreach (var updatedUser in users)
                    {
                         var existingUser = db.Users.FirstOrDefault(u => u.ID == updatedUser.ID);
                         if (existingUser != null && existingUser.Role != updatedUser.Role)
                         {
                              existingUser.Role = updatedUser.Role;
                              db.Entry(existingUser).State = EntityState.Modified;
                         }
                    }
                    db.SaveChanges();
               }

               return RedirectToAction("ManageUsers");
          }
     }
}