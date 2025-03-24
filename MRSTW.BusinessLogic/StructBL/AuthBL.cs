using MRSTW.BusinessLogic.Core;
using MRSTW.BusinessLogic.Interfaces;
using MRSTW.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.BusinessLogic.StructBL
{
     internal class AuthBL : UserApi, IAuth
     {
          public string UserAuthLogin(UserLoginData data) 
          {
               return UserAuthLoginAction(data);
          }
     }
}
