using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MRSTW.Domain.Entities.User;
using System.Runtime.Remoting.Contexts;

namespace MRSTW.Domain.Entities.User
{
     public class UserDBContext : DbContext
     {
          public UserDBContext() : base("name=MRSTW")
          {
          }

          public DbSet<UserDBTable> Users { get; set; }
     }
}
