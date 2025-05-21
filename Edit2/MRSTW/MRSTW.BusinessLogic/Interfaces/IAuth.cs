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
          UserDBTable Login(string username, string password, string ip);
          bool Register(string username, string email, string password, string ip);
     }
}
