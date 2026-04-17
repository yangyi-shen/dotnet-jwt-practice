using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Models.DTOs
{
    public class UserAuthorizationDTO
    {
        public User UserDetails { get; set; } = default!;
        public string JWT { get; set; } = default!;

        public UserAuthorizationDTO(User userDetails, string jwt)
        {
            UserDetails = userDetails;
            JWT = jwt;
        }
    }
}
