﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSTW.Web.Models.Auth
{
     public class AuthUserDataLogin
     {
          [Required]
          public string Username { get; set; }

          [Required]
          [DataType(DataType.Password)]
          public string Password { get; set; }
     }

}
