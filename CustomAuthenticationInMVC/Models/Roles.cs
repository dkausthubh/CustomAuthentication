using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthenticationInMVC.Models
{
    public class Roles
    {
        public enum Role
        {
            SUPERADMIN = 1,
            ADMIN = 2,
            USER = 3,
        }
    }
}