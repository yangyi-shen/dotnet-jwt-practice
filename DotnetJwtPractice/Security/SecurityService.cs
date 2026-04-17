using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotnetJwtPractice.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace DotnetJwtPractice.Security
{
    public class SecurityService
    {
        private readonly IConfiguration _config;

        public SecurityService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwt(Guid userGUID, AuthorizationRole[] roles)
        {
            if (userGUID == Guid.Empty)
            {
                throw new ApiException(ApiExceptions.JWT_USER_GUID_REQUIRED);
            }

            // không định từ tập tin tách ra vì chỉ cho mục đích thử nghiệm nội bộ thôi
            string issuer = _config.GetValue<string>("Jwt:Issuer")!;
            string audience = _config.GetValue<string>("Jwt:Audience")!;

            JwtSecurityTokenHandler handler = new();
            byte[] key = Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:SecretKey")!);

            ClaimsIdentity claimsIdentity = new();

            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Iss, issuer));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Aud, audience));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, userGUID.ToString()));
            claimsIdentity.AddClaim(new Claim("roles", string.Join(",", roles)));

            SecurityTokenDescriptor descriptor = new()
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(_config.GetValue<int>("Jwt:ExpireHours")),
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
