using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Security
{
    public static class SecurityConfig
    {
        public static readonly string JWT_SECRET = "bảo-mật-jwt-cần-phải-dài-hơn-32-chử";
        public static readonly int JWT_EXPIRE_HOURS = 12;
    }
}
