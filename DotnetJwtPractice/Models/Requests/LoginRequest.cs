using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Models.Requests
{
    public class LoginRequest
    {
        public required string UserName { get; set; }
    }
}
