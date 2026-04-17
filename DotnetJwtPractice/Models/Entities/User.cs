using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetJwtPractice.Models
{
    public class User
    {
        [Key]
        public Guid GUID { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User(string userName, bool isAdmin = false)
        {
            GUID = Guid.NewGuid();
            UserName = userName;
            IsAdmin = isAdmin;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
