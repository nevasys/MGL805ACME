using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Common
{
    public enum UserRole
    {
        ADMIN = 1,
        AGENCE = 2,
        CLIENT = 3,
    }

    public static class Commun 
    {
        
        public static string GetUserRole(UserRole role)
        {
            switch(role)
            {
                case UserRole.ADMIN:
                    return "Admin";
                case UserRole.AGENCE:
                    return "Agency";
                case UserRole.CLIENT:
                    return "Client";
                default:
                    return "";
            }
 
        }
    }
}