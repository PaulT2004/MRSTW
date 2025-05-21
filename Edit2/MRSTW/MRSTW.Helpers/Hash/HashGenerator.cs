﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.Helpers.Hash
{
     public class HashGenerator
     {
          public string HashPassword(string password)
          {
               using (var sha = SHA256.Create())
               {
                    var bytes = Encoding.UTF8.GetBytes(password);
                    var hash = sha.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
               }
          }
     }
}
