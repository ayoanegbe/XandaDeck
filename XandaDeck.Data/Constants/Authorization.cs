using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator = 1,
            SuperAdmin = 2,            
            User = 3
        }

        public const string default_username = "user";
        public const string default_email = "user@xandadeck.com";
        public const string default_password = "Pa$$w0rd.";
        public const Roles default_role = Roles.User;
    }
}
