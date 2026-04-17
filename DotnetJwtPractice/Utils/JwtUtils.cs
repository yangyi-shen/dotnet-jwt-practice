using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotnetJwtPractice.Exceptions;
using DotnetJwtPractice.Security;
using Microsoft.IdentityModel.Tokens;

namespace DotnetJwtPractice.Utils
{
    public class JwtUtils
    {
        public string GenerateJwt(Guid userGUID, AuthorizationRole[] roles)
        {
            if (userGUID == Guid.Empty)
            {
                throw new ApiException(ApiExceptions.JWT_USER_GUID_REQUIRED);
            }

            // không định từ tập tin tách ra vì chỉ cho mục đích thử nghiệm nội bộ thôi
            string issuer = "dotnet-jwt-practice";
            string audience = "dotnet-jwt-practice";

            JwtSecurityTokenHandler handler = new();
            byte[] key = Encoding.ASCII.GetBytes(SecurityConfig.JWT_SECRET);

            ClaimsIdentity claimsIdentity = new();

            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Iss, issuer));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Aud, audience));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, userGUID.ToString()));
            claimsIdentity.AddClaim(new Claim("roles", string.Join(",", roles)));

            SecurityTokenDescriptor descriptor = new()
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(SecurityConfig.JWT_EXPIRE_HOURS),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            SecurityToken token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
