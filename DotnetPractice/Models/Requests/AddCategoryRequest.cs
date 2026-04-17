using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Models.Requests
{
    public class AddCategoryRequest
    {
        public required string CategoryName { get; set; }
    }
}
