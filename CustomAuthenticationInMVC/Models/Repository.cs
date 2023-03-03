using CustomAuthenticationInMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthenticationInMVC.Models
{
    public class Repository
    {
        public USER GetUserDetails(string UserName, string Password)
            {
                USER user = new USER();
                using (USER_DBEntities db = new USER_DBEntities())
                {
                    user = db.USERS.FirstOrDefault(u => u.UserName.ToLower() == UserName.ToLower() &&
                                          u.Password == Password);
                }
                return user;
            }
        
    }
}