using MRSTW.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.BusinessLogic.Interfaces
{
     public interface IAuth
     {
          string UserAuthLogin(UserLoginData data);
     }
}
