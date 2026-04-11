using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Models.Responses
{
    public class UserDataDTO : User
    {
        [SetsRequiredMembers]
        public UserDataDTO(User user)
        {
            GUID = user.GUID;
            UserName = user.UserName;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
        }
    }
}
