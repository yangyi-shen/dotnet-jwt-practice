using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Utils
{
    public class CategoryUtils
    {
        public bool validateCategoryName(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
                return false;
            if (categoryName.Length > 50)
                return false;
            return true;
        }
    }
}
