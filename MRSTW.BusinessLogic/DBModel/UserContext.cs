using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.BusinessLogic.DBModel
{
     internal class UserContext : DBContext
     {
          public UserContext() :
               base=("name=MRSTW")
          { 
          }

          public virtual DBSet<UserDBTable> Users {  get; set; }
     }
}
