using MRSTW.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.BusinessLogic.Core
{
     public class UserApi
     {
          
          // Auth

          public string UserAuthLoginAction(UserLoginDTO data) 
          {
               return "token-key";
          }
     }
}
