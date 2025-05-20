using MRSTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.BusinessLogic.Interfaces
{
     public interface IAuth
     {
          UserLoginData Login(string username, string password);
     }
}
