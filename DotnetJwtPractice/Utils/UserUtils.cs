using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Utils
{
    public class UserUtils
    {
        public bool ValidateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;
            if (userName.Length > 50)
                return false;
            return true;
        }
    }
}
