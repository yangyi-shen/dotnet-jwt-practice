using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Utils
{
    public class PostUtils
    {
        public bool validatePostText(string postText)
        {
            if (string.IsNullOrEmpty(postText))
                return false;
            if (postText.Length > 500)
                return false;
            return true;
        }
    }
}
