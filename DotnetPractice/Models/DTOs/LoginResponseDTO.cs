using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Models.Responses
{
    public class LoginResponseDTO : User
    {
        [SetsRequiredMembers]
        public LoginResponseDTO(User user)
        {
            GUID = user.GUID;
            Password = user.Password;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
        }
    }
}
